using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Andrich
{
    public class PlayerShootingPrototype : MonoBehaviourPun
    {
        [Header("Components")]
        [SerializeField] private Camera m_Camera;
        [SerializeField] private Rigidbody m_Rigidbody;
        private PlayerControllerPrototype m_PlayerController;

        [Header("Shooting")]
        [SerializeField] private float m_ShootDelay = 0.25f;
        [SerializeField] private float m_ShootRange = 10f;
        [SerializeField] private float m_RecoilForce = 100;
        private Vector3 m_MousePosition;
        private Vector2 m_AimDirection;
        private bool m_AllowNextShot = true;
        private IEnumerator m_ShootTimer;
        private float m_RecoilStunTime = 0.3f;

        [Header("Projectile")]
        [SerializeField] private Transform m_FirePoint;
        [SerializeField] private float m_FirePointOffset = 2f;
        [SerializeField] private float m_KnockbackForce = 100;
        private float m_KnockbackStunTime = 0.5f;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            m_PlayerController = GetComponent<PlayerControllerPrototype>();
        }

        private void MyUpdate()
        {
            Aim();
        }

        private void MyFixedUpdate()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (m_AllowNextShot)
                {
                    Shoot();

                    m_ShootTimer = ShootTimer(m_ShootDelay);
                    StartCoroutine(m_ShootTimer);
                }
            }
        }

        private void Aim()
        {
            float cameraDistance = Vector3.Dot(m_Rigidbody.position - m_Camera.transform.position, m_Camera.transform.forward);

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cameraDistance;
            m_MousePosition = m_Camera.ScreenToWorldPoint(mousePos);

            m_AimDirection = (m_MousePosition - m_Rigidbody.position).normalized;

            MoveFirepoint();
        }

        private void Shoot()
        {
            RaycastHit2D hit = Physics2D.Raycast(m_FirePoint.position, m_AimDirection, m_ShootRange);
            Debug.DrawRay(m_FirePoint.position, m_AimDirection * m_ShootRange, Color.red, m_ShootDelay);

            m_PlayerController.DisableMovement(m_RecoilStunTime); // Recoil
            m_Rigidbody.AddForce(-m_AimDirection * m_RecoilForce);

            if (hit)
            {
                PlayerControllerPrototype player = hit.collider.GetComponent<PlayerControllerPrototype>(); // Later IHitAble

                if (player)
                {
                    if (hit.rigidbody)
                    {
                        player.DisableMovement(m_KnockbackStunTime);
                        hit.rigidbody.AddForce(-hit.normal * m_KnockbackForce); // Knockback
                    }
                }
            }
        }

        private void MoveFirepoint()
        {
            if (m_AimDirection.magnitude > 0f)
            {
                m_AimDirection.Normalize();
                m_FirePoint.transform.localPosition = m_AimDirection * m_FirePointOffset;
            }
        }

        private IEnumerator ShootTimer(float time)
        {
            m_AllowNextShot = false;

            yield return new WaitForSeconds(time);

            m_AllowNextShot = true;
        }

        private void Update()
        {
            if (photonView.IsMine)
            {
                MyUpdate();
            }
        }

        private void FixedUpdate()
        {
            if (photonView.IsMine)
            {
                MyFixedUpdate();
            }
        }
    }
}

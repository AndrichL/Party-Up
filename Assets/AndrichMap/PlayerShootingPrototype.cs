using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Andrich
{
    public class PlayerShootingPrototype : MonoBehaviour
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
        private Vector3 m_AimDirection;
        private bool m_AllowNextShot = true;
        private IEnumerator m_ShootTimer;
        private float m_RecoilStunTime = 0.3f;

        [Header("Projectile")]
        [SerializeField] private Transform m_FirePoint;
        [SerializeField] private float m_FirePointOffset = 2f;
        [SerializeField] private float m_KnockbackForce = 100;
        private float m_KnockbackStunTime = 0.5f;

        [SerializeField] private ParticleSystem VfxObject;

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
                    VfxObject.Play();
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
           
            Debug.DrawRay(m_FirePoint.position, m_AimDirection.normalized * m_ShootRange, Color.red, m_ShootDelay);

            m_PlayerController.DisableMovement(m_RecoilStunTime); // Recoil
            m_Rigidbody.AddForce(-m_AimDirection * m_RecoilForce);

            RaycastHit hit;
            if (Physics.Raycast(m_FirePoint.position, m_AimDirection, out hit, m_ShootRange))
            {
                Debug.Log("kaas");
                PlayerControllerPrototype player = hit.collider.GetComponent<PlayerControllerPrototype>(); // Later IHitAble

                if (hit.collider.CompareTag("Player"))
                {
                    print("hoi");
                    hit.collider.gameObject.GetComponent<PlayerHealth>().TakeDamage(10); // Later IHitAble
                    print(hit.collider.gameObject + "HitObject");
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
                MyUpdate();
        }

        private void FixedUpdate()
        {
                MyFixedUpdate();
        }
    }
}

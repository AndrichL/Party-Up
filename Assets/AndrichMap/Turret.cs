using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andrich
{
    public class Turret : MonoBehaviour
    {

        [Header("Shooting")]
        [SerializeField] private float m_ShootDelay = 0.25f;
        [SerializeField] private float m_ShootRange = 10f;
        private bool m_AllowNextShot = true;
        private IEnumerator m_ShootTimer;

        [Header("Projectile")]
        [SerializeField] private Transform m_FirePoint;
        [SerializeField] private float m_HitForce = 2000f;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (m_AllowNextShot)
                {
                    RaycastHit2D hit = Physics2D.Raycast(m_FirePoint.position, m_FirePoint.right, m_ShootRange);
                    Debug.DrawRay(m_FirePoint.position, m_FirePoint.right * m_ShootRange, Color.red, 2f);

                    if (hit)
                    {
                        PlayerControllerPrototype player = hit.collider.GetComponent<PlayerControllerPrototype>();

                        if (player)
                        {
                            if (hit.rigidbody)
                            {
                                hit.rigidbody.AddForce(-hit.normal * m_HitForce);
                            }
                        }
                    }

                    m_ShootTimer = ShootTimer(m_ShootDelay);
                    StartCoroutine(m_ShootTimer);
                }
            }
        }

        private IEnumerator ShootTimer(float time)
        {
            m_AllowNextShot = false;

            yield return new WaitForSeconds(time);

            m_AllowNextShot = true;
        }
    }
}


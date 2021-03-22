using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Andrich
{ 

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerControllerPrototype : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField] private Rigidbody m_Rigidbody;

        [Header("Movement")]
        [SerializeField] private float m_MovementSpeed = 5f;
        private bool m_AllowMovement = true;
        private Vector2 m_MovementInput;

        [Header("Jump")]
        [SerializeField] private float m_JumpForce = 5f;
        private bool m_JumpInput;

        [Header("Collision")]
        [SerializeField] private LayerMask m_GroundLayer;
        [SerializeField] private Vector3 m_BottomOffset;
        [SerializeField] private Vector3 m_BottomCollisionSize;
        private bool m_OnGround;

        [SerializeField] private ParticleSystem VfxObject;

        private void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }

        private void MyUpdate()
        {
            m_MovementInput.x = Input.GetAxisRaw("Horizontal");
            m_JumpInput = Input.GetKeyDown(KeyCode.Space);
        }

        private void MyFixedUpdate()
        {
            if(m_AllowMovement)
            {
                MovePlayer(m_MovementInput.x);
            }

            if (m_OnGround)
            {
                VfxObject.Play();
                print("Onground");
                if(m_JumpInput)
                {
                    Jump();
                }
            }

            UpdateOverlapBox();
        }

        private void MovePlayer(float horizontalInput)
        {
            m_Rigidbody.velocity = new Vector2(horizontalInput * m_MovementSpeed, m_Rigidbody.velocity.y);
        }

        private void Jump()
        {
            Debug.Log("Jump");
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, 0, m_Rigidbody.velocity.z);
            m_Rigidbody.AddForce(Vector3.up * m_JumpForce, ForceMode.Impulse);
        }

        public void DisableMovement(float time)
        {
            StartCoroutine(DisableMovementTimer(time));
        }

        private IEnumerator DisableMovementTimer(float time)
        {
            m_AllowMovement = false;

            yield return new WaitForSeconds(time);

            m_AllowMovement = true;
        }

        private void UpdateOverlapBox()
        {
            m_OnGround = Physics.CheckBox(m_Rigidbody.position + m_BottomOffset, m_BottomCollisionSize, Quaternion.identity, m_GroundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(m_Rigidbody.position + m_BottomOffset, m_BottomCollisionSize);
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
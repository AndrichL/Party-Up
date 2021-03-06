using System.Collections;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


namespace Andrich
{ 

    [RequireComponent(typeof(Rigidbody))]
    public class PlayerControllerPrototype : MonoBehaviourPun
    {
        [Header("Debug")]
        public bool IsOnline;
        [SerializeField] int totalHealth = 100;
        [SerializeField] public int currentHealth;

        [SerializeField] ParticleSystem vfxPrefab;
        [SerializeField] ParticleSystem vfxPrefab2;

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
        [SerializeField] private GameObject playerGfx;
        [SerializeField] private GameObject uiGfx;

        private void Start()
        {
            if (currentHealth >= 100)
            {
                currentHealth = totalHealth;
                Debug.LogWarning("ad max health");
            }
            currentHealth = totalHealth;
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
                if(Input.GetKeyDown(KeyCode.Space))
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

        public void TakeDamage(int damage)
        {
           
                currentHealth -= damage;
                if(currentHealth <= 0)
                {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(4);
                }


                vfxPrefab.Play();
          

        }

        public void OnDeath()
        { //elke functie die gebeurd na de player dood gaat;          
            foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
            {
                var pl = player.GetComponent<PlayerControllerPrototype>();
                pl.uiGfx.SetActive(true);
                pl.playerGfx.SetActive(false);
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(4);
            }          
        }


        private void Update()
        {
            
           if(PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                PhotonNetwork.DestroyAll();
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(3);
            }




            if (photonView.IsMine && IsOnline == true)
            {

               

                if (currentHealth <= 0)
                {
                    OnDeath();
                }




                MyUpdate();
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }


            }
           





    }

        private void FixedUpdate()
        {
            if (photonView.IsMine && IsOnline == true)
            {
                MyFixedUpdate();
            }





        }
    }
}
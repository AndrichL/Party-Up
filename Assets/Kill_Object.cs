using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andrich
{
    public class Kill_Object : MonoBehaviour
    {
        private PlayerControllerPrototype player;
        private void Start()
        {
          player = GetComponent<PlayerControllerPrototype>();
        }

        private void OnTriggerEnter(Collider other)
        {
            player.TakeDamage(200);
        }
    }
}
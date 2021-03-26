using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Andrich
{
    public class Kill_Object : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.gameObject.GetComponent<PlayerControllerPrototype>().TakeDamage(200);
        }
    }
}
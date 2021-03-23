using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andrich;
using Photon.Pun;
using Photon.Realtime;
using Photon_Menu;

public class SethealthPowerUp : MonoBehaviourPun
{
    PlayerControllerPrototype PlayerCC;


 


    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerCC = GetComponent<PlayerControllerPrototype>();
            PlayerCC.currentHealth -= 50;
        }
       

    }


}

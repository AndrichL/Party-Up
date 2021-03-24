using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andrich;
using Photon.Pun;
using Photon.Realtime;
using Photon_Menu;

public class SethealthPowerUp : MonoBehaviourPun
{
    [Header("PowerupSettings")]
    public int AddHealt;
    [Header("NetwerkSettings")]
    public bool Isonline;
    [Header("Gameobjects")]
    public GameObject ThisObject;




    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
            Debug.Log("PlayerIncollider");
        }
       

    }


    public void Pickup(Collider other)
    {
        Debug.Log("GettingIT");
        PlayerControllerPrototype healtStats = other.GetComponent<PlayerControllerPrototype>();
        if(healtStats == null)
        {
            Debug.LogWarning("No Script found");
            return;
        }
        healtStats.currentHealth += AddHealt;

        if (Isonline == true)
        {
            PhotonNetwork.Destroy(ThisObject);
        }
        else
        {
            Destroy(ThisObject);
        }


    }


}

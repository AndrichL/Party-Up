using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class PowerupSpawn : MonoBehaviour
{
    public GameObject Powerup;

    public float SpawnTimer;

    public bool Isonline;
   


    void Start()
    {
        StartCoroutine(SpawnPowerup()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPowerup()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnTimer);
            if(Isonline == true)
            {
                PhotonNetwork.InstantiateRoomObject(Path.Combine("PhotonPrefabs", "PowerUP"), Vector3.zero, Quaternion.identity);
            }
            else
            {
                Instantiate(Powerup, Vector3.zero, Quaternion.identity);
            }
            


        }

        

    }
}

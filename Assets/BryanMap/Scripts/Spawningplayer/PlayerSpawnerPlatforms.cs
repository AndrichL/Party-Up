using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class PlayerSpawnerPlatforms : MonoBehaviourPun
{
    public static PlayerSpawnerPlatforms Instance;


  

   [SerializeField] private GameObject PlayerModel1 = null;
    


    public void Start()
    {
       
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerController"), Vector3.zero, Quaternion.identity);
       


        Instance = this;
       

    }




  
}

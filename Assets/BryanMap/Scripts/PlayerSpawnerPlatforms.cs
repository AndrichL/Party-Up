using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;

public class PlayerSpawnerPlatforms : MonoBehaviourPun
{
    public static PlayerSpawnerPlatforms Instance;


    public Transform[] SpawnPoint;

    [SerializeField] private GameObject PlayerModel1 = null;


    public void Start()
    {
        Instance = this;

        


        if(PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < SpawnPoint.Length; i++)
            {
                GameObject Player = PhotonNetwork.Instantiate(PlayerModel1.name, SpawnPoint[i].position, SpawnPoint[i].rotation);
                Player.GetPhotonView().RPC("SetPos", RpcTarget.All, SpawnPoint[i].position.x, SpawnPoint[i].position.y, SpawnPoint[i].position.z);

            }
        }
      

    }

    public void Update()
    {
        
    }
}

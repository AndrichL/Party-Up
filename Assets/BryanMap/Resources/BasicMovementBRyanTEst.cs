using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.IO;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class BasicMovementBRyanTEst : MonoBehaviourPun
{
    [SerializeField] GameObject PlayerModel1;
    PhotonView MyPV;
    GameObject MyPlayer;

    Player[] AllPlayers;

    int MyPlayersInRoom;


    private CharacterController CC = null;
    [SerializeField] private float Speed;
    
    [PunRPC]
    public void SetPos(float X, float Y, float Z)
    {
        transform.position = new Vector3(X, Y, Z);
    }
    public void OnEnable()
    {
        CC = GetComponent<CharacterController>();

        //MyPV = GetComponent<PhotonView>();

        //AllPlayers = PhotonNetwork.PlayerList;

        //foreach (Player player_Local in AllPlayers)
        //{
        //    Debug.Log("CountingPlayer");
        //    if (player_Local != PhotonNetwork.LocalPlayer)
        //    {
        //        MyPlayersInRoom++;
        //        Debug.Log("Adding Players");
        //    }


        //}

        //if (MyPV.IsMine)
        //{
        //    Debug.Log("Spawning In player");
        //    MyPlayer = PhotonNetwork.Instantiate(PlayerModel1.name, PlayerSpawnerPlatforms.Instance.SpawnPoint[MyPlayersInRoom].position, Quaternion.identity);
        //}
    }

    public void Start()
    {
      
      
       
    }


    public void Update()
    {
        if(photonView.IsMine)
        {
            TakeInput();
        }
    }


    public void TakeInput()
    {
        var movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")

        }.normalized;



        CC.SimpleMove(movement * Speed);


    }
}

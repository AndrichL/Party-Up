using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkmangerScript : MonoBehaviourPunCallbacks
{
    public static NetworkmangerScript Instance;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }



    public void Start()
    {
        Debug.Log("Trying To Connect");
        PhotonNetwork.NickName = MasterManger.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManger.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Verbonden met server");
        CreateRoom("testRoom");
        Debug.Log("Name of Local player : " + PhotonNetwork.LocalPlayer.NickName);
      
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server" + cause);
    }

    public void CreateRoom(string RoomName)
    {
        PhotonNetwork.CreateRoom(RoomName);
    }


    public override void OnCreatedRoom()
    {
        Debug.Log("created Room" + PhotonNetwork.CurrentRoom.Name);
    }

    public void JoinRoom(string RoomName)
    {
        PhotonNetwork.JoinRoom(RoomName);
    }

    public void ChangeScene(string SceneName)
    {
        PhotonNetwork.LoadLevel(SceneName);
    }




}

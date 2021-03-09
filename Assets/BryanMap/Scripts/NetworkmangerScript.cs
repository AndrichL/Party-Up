using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkmangerScript : MonoBehaviourPunCallbacks
{
 
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
        //CreateRoom("testRoom");
        Debug.Log("Name of Local player : " + PhotonNetwork.LocalPlayer.NickName);

        PhotonNetwork.JoinLobby();
      
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected from server" + cause);
    }

  




}

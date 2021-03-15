using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TextMeshProUGUI _roomName;

    public void Onclick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected)
            return;
        if(!_roomName)
            return; 


        RoomOptions Options = new RoomOptions();
        Options.MaxPlayers = 4;
        Options.EmptyRoomTtl = 5;




        PhotonNetwork.JoinOrCreateRoom(_roomName.text, Options, TypedLobby.Default);

        // callbacks

        

    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room creation suc6 " + _roomName.text);


    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Room Creation failed");
    }

}

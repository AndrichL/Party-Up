using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class MainMenuScriptPhoton : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject FindOpponentPannel = null;
    [SerializeField] private GameObject WaitstatusPanel = null;
    [SerializeField] private TextMeshProUGUI WaitIngStatusText = null;

    int positionNumber;
    int newPos;
    int numberPlayers;


    private bool IsConecting = false;
    private const string GameVersion = "0.0.1.0";
    private const int MaxPlayersPerRoom = 2;


    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    public void Update()
    {
        if(IsConecting)
        {
          
        }

    }

    public void FindOpponent()
    {
        IsConecting = true;
        FindOpponentPannel.SetActive(false);
        WaitstatusPanel.SetActive(true);

        WaitIngStatusText.text = "Searching.....:}";


        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
            WaitIngStatusText.text = "Conected.....:}";
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            WaitIngStatusText.text = "Checking version and connecting.....:}";
            PhotonNetwork.ConnectUsingSettings();
        }

    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connectet To Master");
        WaitIngStatusText.text = "connecting.....:}";
        if (IsConecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }


    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        WaitstatusPanel.SetActive(false);
     

        Debug.Log($"Player Disconect becaus of: " + cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogError("There Are No Rooms Waiting to be Connectet to you!, try  Creating a New Room to continu ");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom } ); 

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Room joind GoodLuck");

        int PlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if (PlayerCount != MaxPlayersPerRoom)
        {
            WaitIngStatusText.text = "Waiting For Opponents To join. " + PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log("Client Is waiting For Opponents Clients to connect");
        }
        else
        {

            WaitIngStatusText.text = "Opponent Found Waiting for game to Start" + PhotonNetwork.CurrentRoom.PlayerCount;
            Debug.Log("Match is Ready to Begin");
        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
       if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            WaitIngStatusText.text = "Opponent Found Starting game......";
            Debug.LogWarning("CurrentRoom is Full Closing Room to other players untill match is over or player Leaves");


            PhotonNetwork.LoadLevel("HiddeScene");
        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class RoomlistingSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _roomName;

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomName.text = roomInfo + ", " + roomInfo.Name;
    }


}

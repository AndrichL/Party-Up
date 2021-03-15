using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ListRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] RoomlistingSet RoomListingPrefab;
    [SerializeField] private Transform _Content;


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
       foreach(RoomInfo info in roomList)
        {
            RoomlistingSet Listing = Instantiate(RoomListingPrefab, _Content);
            if (Listing != null)
                Listing.SetRoomInfo(info);
        }
    }

}

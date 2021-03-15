using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;
public class PlayerSpawnerPhoton : MonoBehaviour
{
    [SerializeField] private GameObject PlayerModel1 = null;
    public int MaxPlayersInScene;
    
   public void Start()
    {
        if(MaxPlayersInScene <= 4)
        {
            PhotonNetwork.Instantiate(PlayerModel1.name, Vector3.zero, Quaternion.identity);
            MaxPlayersInScene++;
        }
        
    }

   
}

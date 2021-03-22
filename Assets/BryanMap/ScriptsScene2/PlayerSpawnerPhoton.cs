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
            PhotonNetwork.Instantiate(PlayerModel1.name, Vector3.zero, Quaternion.identity);
             
    }

   
}

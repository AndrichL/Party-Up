using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class SetplayerTransform : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
            setSpawnpoint();
       
    }

    public void setSpawnpoint()
    {
        Transform spawnpoint = SpawnManger.Instance.GetSpawnPoints();
        transform.position = spawnpoint.position;
        transform.rotation = spawnpoint.rotation;
    }
}

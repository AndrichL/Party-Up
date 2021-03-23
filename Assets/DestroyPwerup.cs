using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class DestroyPwerup : MonoBehaviourPun
{
    public float DestroyTimer;
    public bool Isonline;

    public GameObject ThisObject;

    public void OnEnable()
    {
        StartCoroutine(DestroyTimerIE());
    }


    IEnumerator DestroyTimerIE()
    {

        yield return new WaitForSeconds(DestroyTimer);
        if(Isonline == true)
        {
            PhotonNetwork.Destroy(ThisObject);
        }
        else
        {
            Destroy(ThisObject);
        }
        StopCoroutine(DestroyTimerIE());

    }
}

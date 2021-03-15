using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class PlayerNameTags : MonoBehaviourPun
{

    [SerializeField] private TextMeshProUGUI NameTag;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            return;
        }


        Setname();


    }

    public void Setname()
    {
        NameTag.text = photonView.Owner.NickName;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

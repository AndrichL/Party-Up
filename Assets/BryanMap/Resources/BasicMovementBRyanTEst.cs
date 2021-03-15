using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon_Menu;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterController))]
public class BasicMovementBRyanTEst : MonoBehaviourPun
{
  

    private CharacterController CC = null;
    [SerializeField] private float Speed;
    
    [PunRPC]
    public void SetPos(float X, float Y, float Z)
    {
        transform.position = new Vector3(X, Y, Z);
    }


    public void Start()
    {
        CC = GetComponent<CharacterController>();



      

    }


    public void Update()
    {
        if(photonView.IsMine)
        {
            TakeInput();
        }
    }


    public void TakeInput()
    {
        var movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")

        }.normalized;



        CC.SimpleMove(movement * Speed);


    }
}

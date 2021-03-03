using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NetworkMasterManger/GameSettings")]


public class GameSettings : ScriptableObject
{
    [SerializeField] private string _GameVersion = "0.0.0";

    public string GameVersion {get { return _GameVersion; } }

    [SerializeField] private string _NickName = "Party-Up";


    public string NickName
    {
        get
        {
            int value = Random.Range(1, 9999);
            return _NickName + value.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "NetworkMasterManger/MasterManger")]
public class MasterManger : ScriptOBJSingelton<MasterManger>
{
    [SerializeField] private GameSettings _gameSettings;

    public static GameSettings GameSettings { get { return Instance._gameSettings; } }




}

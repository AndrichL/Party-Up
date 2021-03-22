using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public static SpawnManger Instance;

    public SpawnpointSet[] points;
    public void Awake()
    {
        Instance = this;
        
    }

    

    public Transform GetSpawnPoints()
    {
        return points[Random.Range(0, points.Length)].transform;
    }
}

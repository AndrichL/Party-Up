using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnpointSet : MonoBehaviour
{
    [SerializeField] GameObject Graphics;

    private void Awake()
    {
        Graphics.SetActive(false);
    }
}

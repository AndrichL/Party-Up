using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("GameState")]
    public bool gameIsPaused;   
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;

        else
            return;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

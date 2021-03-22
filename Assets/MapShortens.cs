using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShortens : MonoBehaviour
{
    [SerializeField] private List<GameObject> Deleteables;
    [SerializeField] private float timer;
    [SerializeField] private float shakeTimer = 2f;
    public CameraShake cameraShake;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            foreach (GameObject deleteable in Deleteables)
            {
                deleteable.SetActive(false);
            }
            Destroy(this.gameObject);
        }

        if (timer <= 2f)
        {
            StartCoroutine(cameraShake.Shake(shakeTimer, .1f));
        }
    }
}

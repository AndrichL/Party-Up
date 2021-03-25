using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShortens : MonoBehaviour
{
    [SerializeField] private List<GameObject> Deleteables;
    [SerializeField] private float timer;
    [SerializeField] private float shakeTimer = 2f;
    public CameraShake cameraShake;

    private bool canShake = true;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            foreach (GameObject deleteable in Deleteables)
            {
                deleteable.SetActive(false);
            }
            this.gameObject.SetActive(false);
            StopCoroutine(cameraShake.Shake(0,0));
        }

        if (timer <= 2f && canShake)
        {
            StartCoroutine(cameraShake.Shake(shakeTimer, .1f));
            canShake = false;
        }
    }
}

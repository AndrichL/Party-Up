using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public CoolCamera cameraScript;
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 ogPos = transform.position += cameraScript.centerPoint;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(ogPos.x - .2f, ogPos.x + .2f) * magnitude;
            float y = Random.Range(ogPos.y - .2f, ogPos.y + .2f) * magnitude;

            transform.position = new Vector3(x + cameraScript.centerPoint.x, y + cameraScript.centerPoint.y, ogPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = ogPos;
    }
}

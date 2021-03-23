using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class CoolCamera : MonoBehaviour
{
    public List<Transform> followTargets;
    [SerializeField] Vector3 offset;
    private Vector3 velocity;
    public float dampTime;

    public Vector3 centerPoint;

    public float minZoom = 50;
    public float maxZoom = 10;

    public float zoomLimiter;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (followTargets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }

    private void Move() 
    {
        centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, dampTime);
    }
    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance()/ zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(followTargets[0].position, Vector3.zero);
        for (int i = 0; i < followTargets.Count; i++)
        {
            bounds.Encapsulate(followTargets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (followTargets.Count == 1)
        {
            return followTargets[0].position;
        }

        var bounds = new Bounds(followTargets[0].position, Vector3.zero);
        for (int i = 0; i < followTargets.Count; i++)
        {
            bounds.Encapsulate(followTargets[i].position);
        }

        return bounds.center;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float cameraAcceleration;
    [SerializeField] private Vector3 offset;

    public void FixedUpdate()
    {
        Vector3 targetPos = playerPos.position + offset;
        Vector3 lerpPos = Vector3.Lerp(transform.position, targetPos, cameraAcceleration);
        transform.position = lerpPos;
    }
}

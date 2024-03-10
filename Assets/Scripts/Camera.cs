using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float smoothSpeed = 0.125f;

    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // playerTransform.position);
            Vector3 desiredPosition = playerTransform.position;
            Vector3 newPosition = Vector3.Lerp(playerTransform.position, desiredPosition, smoothSpeed);
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
    }
}
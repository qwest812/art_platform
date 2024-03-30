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
            Vector3 playerPosition = playerTransform.position;
            Vector3 desiredPosition = new Vector3(playerPosition.x, playerPosition.y + 15, playerPosition.z);     
            Vector3 newPosition = Vector3.Lerp(playerTransform.position, desiredPosition, smoothSpeed);
            newPosition.z = -10;
            transform.position = newPosition;
        }
    }
}
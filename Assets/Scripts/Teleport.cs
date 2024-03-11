using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // [SerializeField] private Transform startPosition; 
    [SerializeField] private Transform NewPosition;
    [SerializeField] private KeyCode inputKey;
    private bool inTeleportArea;
    private Collider2D playerColider;
    [SerializeField] private float correct;


    private void Update()
    {
        if (inTeleportArea && Input.GetKeyDown(KeyCode.E))
        {
            Vector3 newPosition = playerColider.transform.position;
            newPosition.x = NewPosition.position.x;
            newPosition.y = NewPosition.position.y - correct;
            playerColider.transform.position = newPosition;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTeleportArea = true;
            playerColider = other;
        }

        {
            // Vector3 newPosition = other.transform.position;
            // newPosition.x = transform.position.x;
            // newPosition.y = transform.position.y+ 0.5f;
            // other.transform.position = newPosition;


            // Vector3 newPosition = other.transform.position;

            // Debug.Log("Player entered the teleporter trigger zone!");
            // Implement your teleportation logic here
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTeleportArea = false;
            playerColider = null;
        }
    }
}
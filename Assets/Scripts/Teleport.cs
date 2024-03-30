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


    private void Update()
    {
        if (inTeleportArea && Input.GetKeyDown(inputKey))
        {
            Debug.Log(NewPosition.position.y);
            Vector3 newPosition = playerColider.transform.position;
            newPosition.x = NewPosition.position.x;
            newPosition.y = NewPosition.position.y;
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
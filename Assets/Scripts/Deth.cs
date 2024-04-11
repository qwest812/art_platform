using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deth : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.MoveToCheckPoint();
            }            
        }
    }
}

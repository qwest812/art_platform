using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.isTrigger == false)
        {
            col.gameObject.GetComponent<Player>().addCrystal();
            col.gameObject.GetComponent<Player>().MoveToCheckPoint();
            Destroy(gameObject);
        }
    }
}

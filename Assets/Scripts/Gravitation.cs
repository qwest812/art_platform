using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public float gravityScaleUp = -1f; // Гравитация вверх (по умолчанию -1)
    public float gravityScaleDown = 1f; // Гравитация вниз (по умолчанию 1)

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb.gravityScale == gravityScaleUp)
            {
                return;
            }
            Vector2 pos = rb.position;
            rb.gravityScale = gravityScaleUp;
            rb.transform.Rotate(Vector3.forward, 180f);
            pos.y += 1;
            rb.position = pos;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            Vector2 pos = rb.position;
            rb.gravityScale = gravityScaleDown;
            rb.transform.Rotate(Vector3.forward, -180f);
            pos.y -= 1;
            rb.position = pos;
        }
    }
    // void Update()
    // {
    //     if (Input.GetKeyDown(flipGravityKey))
    //     {
    //         Vector2 pos = rb.position;
    //         // Изменяем направление гравитации и поворачиваем персонаж
    //         if (rb.gravityScale == gravityScaleDown)
    //         {
    //             rb.gravityScale = gravityScaleUp;
    //             transform.Rotate(Vector3.forward, 180f);
    //
    //             pos.y += 1;
    //             rb.position = pos;
    //         }
    //         else
    //         {
    //             rb.gravityScale = gravityScaleDown;
    //             transform.Rotate(Vector3.forward, -180f);
    //             pos.y -= 1;
    //             rb.position = pos;
    //         }
    //     }
    // }
}
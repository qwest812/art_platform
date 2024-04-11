using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlatform : MonoBehaviour
{
        
        
        private void Update()
        {
                // Пускаем луч вниз от платформы
                RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up);

                // Отображаем луч в редакторе Unity
                Debug.DrawRay(transform.position, Vector2.up * hit.distance, Color.yellow);

                // Проверяем, что луч попал в игрока
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                        Debug.Log("Игрок наступил на платформу сверху");
                        // Ваш код для обработки ситуации, когда игрок наступил на платформу сверху
                }
        }
        // private void OnCollisionEnter(Collision col)
        // {
        //         if (col.collider.CompareTag("Player"))
        //         {
        //                 
        //         }
        // }
}


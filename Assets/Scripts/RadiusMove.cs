using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusMove : MonoBehaviour
{
    public Transform centerPoint; // Центр, относительно которого будет движение
    public float radius = 5f; // Радиус движения
    public float speed = 2f; // Скорость движения

    private float angle = 0f;

    void Update()
    {
        // Увеличиваем угол в зависимости от времени и скорости
        angle += speed * Time.deltaTime;

        // Вычисляем новую позицию на круге
        float x = centerPoint.position.x + Mathf.Cos(angle) * radius;
        float z = centerPoint.position.z + Mathf.Sin(angle) * radius;

        // Присваиваем новую позицию объекту
        transform.position = new Vector3(x, transform.position.y, z);
    }
}

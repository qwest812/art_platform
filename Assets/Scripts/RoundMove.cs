using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundMove : MonoBehaviour
{
    public float speed = 2f; // Базовая скорость движения
    public float minSpeed = 0.5f; // Минимальная скорость для дочерних объектов
    public float maxSpeed = 5f; // Максимальная скорость для дочерних объектов

    private float angle; // Угол, на который поворачивается объект

    void Update()
    {
        // Увеличиваем угол на основе скорости и времени
        angle += speed * Time.deltaTime;

        // Получаем центр родительского объекта
        Vector3 center = transform.position;

        // Проходимся по всем дочерним объектам
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Получаем текущее расстояние от дочернего объекта до центра родительского объекта
            float distance = Vector3.Distance(child.position, center);

            // Вычисляем скорость на основе расстояния от центра
            float currentSpeed = Mathf.Lerp(maxSpeed, minSpeed, distance / maxSpeed);

            // Вычисляем новый угол для каждого дочернего объекта
            float radians = angle + (currentSpeed * Time.deltaTime) * Mathf.Deg2Rad;

            // Вычисляем новую позицию дочернего объекта на окружности
            float x = center.x + Mathf.Cos(radians) * distance;
            float y = center.y + Mathf.Sin(radians) * distance;

            // Перемещаем дочерний объект к новой позиции
            child.position = new Vector3(x, y, child.position.z);
        }
    }
}

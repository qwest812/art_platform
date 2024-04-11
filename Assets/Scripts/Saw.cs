using UnityEngine;

public class Saw : MonoBehaviour
{
    public Transform[] points; // Массив точек, к которым нужно двигаться
    public float speed = 5f; // Скорость перемещения

    private int currentTargetIndex = 0; // Индекс текущей целевой точки

    private void Update()
    {
        // Если массив точек пуст или текущий индекс за пределами массива, выходим из метода
        if (points == null || points.Length == 0 || currentTargetIndex >= points.Length)
            return;

        // Направление к текущей целевой точке
        Vector3 direction = points[currentTargetIndex].position - transform.position;
        // Нормализуем направление, чтобы оно имело длину 1
        direction.Normalize();
        // Движение в направлении текущей целевой точки с определенной скоростью
        transform.position += direction * speed * Time.deltaTime;

        // Если объект приблизился достаточно к текущей целевой точке, выбираем следующую точку
        if (Vector3.Distance(transform.position, points[currentTargetIndex].position) < 0.1f)
        {
            currentTargetIndex++; // Увеличиваем индекс для выбора следующей точки
            // Если достигли последней точки, возвращаемся к первой
            if (currentTargetIndex >= points.Length)
                currentTargetIndex = 0;
        }
    }
}
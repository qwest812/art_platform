using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    public Transform[] points;
    public Animator _animator;

    private int currentPoint;
    public float speed;
    private string animationName;

    void FixedUpdate()
    {
        PointsMovement();
    }

    private void Start()
    {
        if (points.Length > 0)
        {
            transform.position = points[0].position;
            currentPoint = 0;
        }
        else
        {
            Debug.LogError("points minimun 1");
        }
    }

    private void PointsMovement()
    {
        Transform nextPosition = points[currentPoint];
        StartCoroutine(MovePlatform());
        if (transform.position == nextPosition.position)
        {
            Transform prevPos;
            if (currentPoint == 0)
            {
                prevPos = points[points.Length - 1];
            }
            else
            {
                prevPos = points[currentPoint - 1];
            }

            // Получаем разницу между координатами X и Y двух точек
            float deltaX = nextPosition.position.x - prevPos.position.x;
            float deltaY = nextPosition.position.y - prevPos.position.y;
// Определяем направление движения объекта
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
            {
                if (deltaX > 0)
                {
                    animationName = "RightHit"; ;
                    Debug.Log("Движение с лева на право");
                }
                else
                {
                    animationName = "LeftHit";
                    Debug.Log("Движение с права на лево");
                }
            }
            else
            {
                if (deltaY > 0)
                {
                    animationName = "TopHit";
                    Debug.Log("Движение с низу вверх");
                }
                else
                {
                    animationName = "BottomHit";
                    Debug.Log("Движение сверху вниз");
                }
            }
            _animator.Play(animationName);
            currentPoint++;
            if (points.Length == currentPoint)
            {
                currentPoint = 0;
            }
        }

        IEnumerator MovePlatform(float delay = 1f)
        {
            yield return new WaitForSeconds(delay);
            transform.position = Vector3.MoveTowards(transform.position, nextPosition.position, speed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] points;

    public int currentPoint;
    private Vector3 targetPosition;

    public float speed;
    public float speedAttack;
    public float sppedCuldow;

    public Transform player;

    public bool culdown;
    public float culdownTime;
    public int damage;

    private SpriteRenderer _spriteRenderer;

    private Rigidbody2D _rb;
    // Start is called before the first frame update

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            if (culdown == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speedAttack);
                targetPosition = player.position;
            }
            else
            {
                Vector3 culdownPosition = player.position;
                culdownPosition.y += 2;
                transform.position = Vector3.MoveTowards(transform.position, player.position, sppedCuldow);
                targetPosition = culdownPosition;
            }
        }
        else
        {
            PointsMovement();
        }
        _rb.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (transform.position.x > targetPosition.x)
        {
            _spriteRenderer.flipX = false;
        }
        else if (transform.position.x < targetPosition.x)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = col.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            player = null;
        }
    }

    private void PointsMovement()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[currentPoint].position, speed);
        targetPosition = points[currentPoint].position;
        if (transform.position == points[currentPoint].position)
        {
            currentPoint++;
            if (points.Length == currentPoint)
            {
                currentPoint = 0;
            }
        }
    }

    private IEnumerator culdownTimer()
    {
        yield return new WaitForSeconds(culdownTime);
        culdown = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            culdown = true;
            StartCoroutine(culdownTimer());
        }
    }
}
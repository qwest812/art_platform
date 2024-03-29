using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speed = 0.1f;
    public LayerMask groundLayer;
    public float speedUp = 2f;
    public float speedDown = 2f;


    private Vector3 _prevPosition;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private Animator _animator;

    void Start()
    {
        _prevPosition = transform.position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.4f),
            new Vector2(transform.position.x + 0.2f, transform.position.y - 0.31f),
            groundLayer);

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.Play("Walk");
        }
        else
        {
            _animator.Play("idle");
        }
    }

    private void FixedUpdate()
    {
        HandleMovement(speed);

        if (Input.GetKeyDown(KeyCode.T))
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            GetComponent<Rigidbody2D>().gravityScale *= -1;
        }
    }

    void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }

    private void HandleMovement(float moveSpeed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed *= speedUp;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            moveSpeed /= speedDown;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed;
            _spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed;
            _spriteRenderer.flipX = false;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Collider2D collidedCollider = collision.collider;
        if (collidedCollider != null)
        {
            // Do something with the collided collider
            Debug.Log("Collided with: " + collidedCollider.name);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            _prevPosition = transform.position;
        }
    }

    public void MoveToPrevPosition()
    {
        _prevPosition.x -= 0.5f;
        transform.position = _prevPosition;
    }
}
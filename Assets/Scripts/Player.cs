using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 5f;
    public float speed = 0.1f;
    public LayerMask groundLayer;
    public float speedUp = 2f;
    public float speedDown = 2f;
    public Renderer spriteRender;

    public GameObject[] crystals;
    
    private int amountCrystal = 0;
    private Vector3 _prevPosition;
    private Rigidbody2D _rb;
    private Transform _checpoint;
    private bool _isGrounded;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private bool _isGravityChange;


    // Определение переменных за пределами методов, чтобы они были доступны везде в классе
    private Vector2 bottomLeft;
    private Vector2 topRight;

    void Start()
    {
        _prevPosition = transform.position;
        _rb = GetComponent<Rigidbody2D>();
        _animator = spriteRender.GetComponent<Animator>();
        _sprite = spriteRender.GetComponent<SpriteRenderer>();
        for (int i = crystals.Length - 1; i >= 0; i--)
        {
            crystals[i].SetActive(false);
        }
    }

    // Метод, вызываемый Unity для визуализации гизмо
    private void OnDrawGizmos()
    {
        // Обновление координат для OverlapArea
        UpdateOverlapAreaCoordinates();

        // Визуализация OverlapArea в редакторе Unity
        Gizmos.color = Color.red;
        Gizmos.DrawLine(bottomLeft, new Vector2(topRight.x, bottomLeft.y));
        Gizmos.DrawLine(new Vector2(topRight.x, bottomLeft.y), topRight);
        Gizmos.DrawLine(topRight, new Vector2(bottomLeft.x, topRight.y));
        Gizmos.DrawLine(new Vector2(bottomLeft.x, topRight.y), bottomLeft);
    }

    // Метод для обновления координат OverlapArea
    private void UpdateOverlapAreaCoordinates()
    {
        if (_isGravityChange)
        {
            bottomLeft = new Vector2(transform.position.x + 0.3f, transform.position.y + 1.2f);
            topRight = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.35f);
        }
        else
        {
            bottomLeft = new Vector2(transform.position.x - 0.3f, transform.position.y - 0.05f);
            topRight = new Vector2(transform.position.x + 0.3f, transform.position.y + 0.1f);
        }
    }

    void Update()
    {
        if (_isGravityChange)
        {
            bottomLeft = new Vector2(transform.position.x + 0.3f, transform.position.y + 1.2f);
            topRight = new Vector2(transform.position.x - 0.3f, transform.position.y + 1.35f);
        }
        else
        {
            bottomLeft = new Vector2(transform.position.x - 0.3f, transform.position.y - 0.05f);
            topRight = new Vector2(transform.position.x + 0.3f, transform.position.y + 0.1f);
        }

        _isGrounded = Physics2D.OverlapArea(bottomLeft, topRight, groundLayer);

        if (_isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _animator.SetInteger("State", 1);
            // _animator.Play("Walk");
        }
        else
        {
            _animator.SetInteger("State", 0);
            // _animator.Play("idle");
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
        if (_isGravityChange)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, -jumpForce);
        }
        else
        {
            _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        }
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
            _sprite.flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed;
            _sprite.flipX = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
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

    public void MoveToPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void MoveToCheckPoint()
    {
        transform.position = _checpoint.position;
    }

    public void GravityChange(bool isGravity, float gravityValue)
    {
        if (isGravity && !_isGravityChange)
        {
            _sprite.flipY = true;
            Vector2 renderPos = spriteRender.transform.position;
            renderPos.y += 1.3f;
            spriteRender.transform.position = renderPos;
            Vector2 playerPos = transform.position;
            playerPos.y += 1.3f;
            _rb.gravityScale = gravityValue;
            _isGravityChange = true;
        }

        if (!isGravity && _isGravityChange)
        {
            _sprite.flipY = false;
            Vector2 renderPos = spriteRender.transform.position;
            renderPos.y -= 1.3f;
            spriteRender.transform.position = renderPos;
            Vector2 playerPos = transform.position;
            playerPos.y -= 1.3f;
            _rb.gravityScale = gravityValue;
            _isGravityChange = false;
        }
    }

    public void addCrystal()
    {
        crystals[amountCrystal].SetActive(true);
        amountCrystal++;
    }

    public void UpdateCheckPoint(Transform pos)
    {
        _checpoint = pos;
    }
}
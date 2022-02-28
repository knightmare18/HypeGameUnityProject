using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 1.5f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public float jumpForce = 4.5f;
    public float longIdleTime = 5f;
    public Transform spawnpoint;
    

    //References
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private bool _facingRight = true;
    private bool _isGrounded;

    //Movement
    private Vector2 _movement;
    //Attack
    private bool _isAttacking;
    private float _longIdleTimer;
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        spawnpoint = GetComponent<Transform>();

    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(spawnpoint.transform.position.x, spawnpoint.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    //Movement
    { if (_isAttacking == false)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            _movement = new Vector2(horizontalInput, 0f);

            if (horizontalInput < 0f && _facingRight == true)
            {
                Flip();
            }
            else if (horizontalInput > 0f && _facingRight == false)
            {
                Flip();
            }
        }

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetButtonDown("Jump") && _isGrounded == true && _isAttacking == false)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce * 1.5f, ForceMode2D.Impulse);
        
        }

        //Atacking
        if (Input.GetButtonDown("Fire1") && _isGrounded == true && _isAttacking == false)
        {
            _movement = Vector2.zero;
            _rigidbody.velocity = Vector2.zero;
            _animator.SetTrigger("Attack");
        }
    }

    void FixedUpdate()
    {
        if (_isAttacking == false)
        {
            float horizontalVelocity = _movement.normalized.x * speed;
            _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
        }
    }
    void LateUpdate()
    {
        _animator.SetBool("Idle", _movement == Vector2.zero);
        _animator.SetBool("isGrounded", _isGrounded);
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);

        //Attack
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            _isAttacking = true;
        }
        else
        {
            _isAttacking = false;
        }
        if (_animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            _longIdleTimer += Time.deltaTime;
            if (_longIdleTimer >= longIdleTime)
            {
                _animator.SetTrigger("LongIdle");
            }
        }
        else
        {
            _longIdleTimer = 0f;
        }
    }
    void Flip()
    {
        _facingRight = !_facingRight;
        float localScaleX = transform.localScale.x;
        localScaleX *= -1;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

}   

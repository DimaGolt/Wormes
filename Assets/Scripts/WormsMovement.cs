using System.Collections;
using UnityEngine;

public class WormsMovement : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 5f;  // Speed at which the character moves
    [SerializeField]
    public float jumpForce = 5f;  // Force applied when jumping
    [SerializeField]
    public float groundCheckRadius = 0.2f;  // Radius of the ground check sphere
    public LayerMask groundLayer;  // Layer(s) considered as ground

    private Rigidbody2D _rb;  // Reference to the character's Rigidbody2D component
    private Animator _animator;
    private bool _isGrounded;  // Flag to check if the character is grounded
    private float _jumpDirection = 1f;  
    private bool _isJumping = false; // Flag to check if the character is currently jumping
    
    
    
    private static readonly int StartJumping = Animator.StringToHash("StartingJump");
    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Flying = Animator.StringToHash("Flying");

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the character is on the ground
        _isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
        
        

        if (_isGrounded && !_isJumping)
        {
            // Read user input for movement
            float moveInput = Input.GetAxis("Horizontal");

            // Update jump direction if moving
            if (moveInput != 0f)
                _jumpDirection = Mathf.Sign(moveInput);

            // Apply horizontal movement
            _rb.velocity = new Vector2(moveInput * moveSpeed, _rb.velocity.y);

            // Flip the character sprite based on movement direction
            Vector3 previousScale = transform.localScale;

            if (moveInput == 0)
                _animator.SetBool(Walking, false);
            else
                _animator.SetBool(Walking, true);

            if (moveInput > 0 && Mathf.Sign(previousScale.x) != 1)
                transform.localScale = new Vector3(-previousScale.x, previousScale.y, previousScale.z);
            else if (moveInput < 0 && Mathf.Sign(previousScale.x) != -1)
                transform.localScale = new Vector3(-previousScale.x, previousScale.y, previousScale.z);

            // Check for jump input
            if (Input.GetButtonDown("Jump"))
            {
                // Set jumping flag to true and apply the jump force
                _isJumping = true;
                _animator.SetBool(StartJumping, true);
                _rb.velocity = new Vector2(0f, 0f);
                StartCoroutine(Jump());
            }
        }

        // Check if the character is currently jumping
        // if (_isJumping)
        // {
        //     _rb.velocity = new Vector2(_rb.velocity.x , _rb.velocity.y);
        // }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reset jumping flag when landing on the ground
        if (collision.gameObject.CompareTag("Floor"))
        {
            _isJumping = false;
            _animator.SetBool(Flying, false);
        }
    }

    private IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.6f);
        _animator.SetBool(StartJumping, false);
        _animator.SetBool(Flying, true);
        _rb.AddForce( new Vector2(_jumpDirection * 200f, 200f));
    }
}
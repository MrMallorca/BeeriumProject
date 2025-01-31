using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings.SplashScreen;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]

    public float speed;

    public float extraGravityForce = 10f;
    public float jumpForce = 5f;
    private bool isGrounded = true;


    Rigidbody characterRb;


    [Header("Input Actions")]

    [SerializeField] InputActionReference jump;
    [SerializeField] InputActionReference move;



    Animator anim;

    [SerializeField] Transform enemyPlayer;
    private SpriteRenderer spriteRenderer;
    private void OnEnable()
    {
        move.action.Enable();

        jump.action.Enable();

        jump.action.performed += OnJump;
        jump.action.canceled += OnJump;

        move.action.performed += OnMove;
        move.action.started += OnMove;
        move.action.canceled += OnMove;

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterRb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateAnimatorParameters();

        Vector3 direction = enemyPlayer.position - transform.position;

        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        UpdateMovementOnPlane();
    }

    Vector3 rawMove = Vector3.zero;
    void UpdateMovementOnPlane()
    {
        Vector3 moveDirection = rawMove * speed;
        Vector3 velocity = new Vector3(moveDirection.x, characterRb.linearVelocity.y, moveDirection.z); 
        characterRb.linearVelocity = velocity;



        characterRb.AddForce(Vector3.down * extraGravityForce, ForceMode.Acceleration);

    }


    private void UpdateAnimatorParameters()
    {
        float horizontalSpeed = characterRb.linearVelocity.x;

        anim.SetFloat("Speed", horizontalSpeed);

        if (horizontalSpeed > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalSpeed < -0.01f)
        {
            spriteRenderer.flipX = true;
        }


    }
 
  



    void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGrounded) 
        {
            isGrounded = false;
            characterRb.linearVelocity = new Vector3(characterRb.linearVelocity.x, jumpForce, characterRb.linearVelocity.z);
            anim.SetBool("IsGrounded", false);
            anim.SetTrigger("Jump");
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 rawInput = context.ReadValue<Vector2>();
        rawMove = new Vector3(rawInput.x, 0f, rawInput.y);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", true);
        }
    }

    private void OnDisable()
    {
        move.action.Disable();
        jump.action.performed -= OnJump;
        jump.action.canceled -= OnJump;


        jump.action.Disable();

        move.action.performed -= OnMove;
        move.action.started -= OnMove;
        move.action.canceled -= OnMove;

    }

}
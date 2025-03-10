using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
//using static UnityEditor.PlayerSettings.SplashScreen;

public class Diana : MonoBehaviour
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
    [SerializeField] InputActionReference crouch;
    [SerializeField] InputActionReference normalAttack;
    [SerializeField] InputActionReference strongAttack;

    [Header("Animation Settings")]

    Animator anim;

    [SerializeField] Transform enemyPlayer;
    private SpriteRenderer spriteRenderer;



    [Header("Attacks Parameters")]

    private bool canAttack;
    private int nroAttack;

  


    private void OnEnable()
    {
        move.action.Enable();

        jump.action.Enable();

        normalAttack.action.Enable();

        strongAttack.action.Enable();


        crouch.action.Enable();

        jump.action.performed += OnJump;
        jump.action.canceled += OnJump;

        crouch.action.performed += OnCrouch;
        crouch.action.canceled += OnCrouch;

        normalAttack.action.performed += OnNormalAttack;
        normalAttack.action.canceled += OnNormalAttack;

        strongAttack.action.performed += OnStrongAttack;
        strongAttack.action.canceled += OnStrongAttack;

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
        
        canAttack = true;
        nroAttack = 0;

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

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && nroAttack == 0)
        {
            canAttack = true;
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
    void OnNormalAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGrounded)
        {
            if (rawMove.z < -0.1f)
            {
                anim.SetTrigger("normalAttackDown");

            }
            else if (rawMove.z > 0.1f)
            {
                anim.SetTrigger("normalAttackUp");

            }
            else if (rawMove.x > 0.1f)
            {
                anim.SetTrigger("normalAttackRight");

            }
            else if(canAttack && nroAttack < 3)
            {
                nroAttack++;
                if (nroAttack == 1)
                    anim.SetInteger("AttackCount", nroAttack);
                canAttack = false;
            }
        }
    }

    void OnStrongAttack(InputAction.CallbackContext ctx)
    {

        if (ctx.performed && isGrounded)
        {
            if(rawMove.z < 0f)
            {
                //anim.SetBool("strongAttackDownCharge", true);

            }
            else
            {
                anim.SetBool("strongAttackCharge", true);

            }
        }
        if (ctx.canceled)
        {
            if (rawMove.z < 0f)
            {
                //anim.SetBool("strongAttackDownCharge", false);

                //anim.SetBool("strongAttackCharge", false);


                //anim.SetTrigger("strongAttackDown");

            }
            else
            {
                //anim.SetBool("strongAttackDownCharge", false);

                anim.SetBool("strongAttackCharge", false);


                anim.SetTrigger("strongAttack");
            }

         
        }
    }


    private void OnCrouch(InputAction.CallbackContext ctx)
    {

        if (isGrounded)
        {
            anim.SetBool("crouch", ctx.ReadValue<float>() > 0);
            canAttackTrue();
            nroAttack = 0;
            anim.SetInteger("AttackCount", nroAttack);
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 rawInput = context.ReadValue<Vector2>();
        rawMove = new Vector3(rawInput.x, 0f, rawInput.y);
        Debug.Log(rawMove); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", true);
        }
    }



    public void VerificaCombo()
    {
       

        if (canAttack)
        {
            nroAttack = 0;
            canAttack = false;
            anim.SetInteger("AttackCount", nroAttack);
        }
        else
        {
            if (nroAttack > 1)
                anim.SetInteger("AttackCount", nroAttack);
        }
    }

    public void canAttackTrue()
    {
        canAttack = true;
    }

   

    private void OnDisable()
    {
        jump.action.Disable();

        jump.action.performed -= OnJump;
        jump.action.canceled -= OnJump;

        normalAttack.action.Disable();

        normalAttack.action.performed -= OnNormalAttack;
        normalAttack.action.canceled -= OnNormalAttack;

        crouch.action.performed -= OnCrouch;
        crouch.action.canceled -= OnCrouch;

        move.action.Disable();

        move.action.performed -= OnMove;
        move.action.started -= OnMove;
        move.action.canceled -= OnMove;

    }

}
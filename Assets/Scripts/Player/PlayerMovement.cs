
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private bool canMove = true;
    private Rigidbody2D body;
    private Animator animator;
    private bool isJumping = false;
    private bool grounded;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask stairs;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private int doubleJump = 0;
    [SerializeField]private int SPEED;
    private bool isStairs = false;
    
    private bool isFacingWall;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(canMove)
        {
            body.velocity = new Vector2(horizontalInput * SPEED, body.velocity.y);
        }
        if (isStair())
        {
            print("Uso");
            body.velocity = new Vector2(body.velocity.x, horizontalInput * SPEED);
        }else body.velocity = new Vector2(horizontalInput * SPEED, body.velocity.y);

        if (horizontalInput > 0.01f) { 
            transform.localScale = new Vector3(2,2,2);
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (isGrounded())
        {
            doubleJump = 0;
            isJumping = false;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded()){
          
            Jump();

            if (isJumping == true && Input.GetKey(KeyCode.Space) && doubleJump <= 2)
            {
                Jump();
                
            }

        }
        
        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", isGrounded());

        if (isWall() && !isGrounded())
        {
            canMove = false;

        }
        else EnableMovement();
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, SPEED);
        animator.SetTrigger("jump");
        doubleJump += 1;
        isJumping = true;
     
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            print("Check true");
            isStairs = true;

        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            print("Check true");
            isStairs = false;

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Stairs"))
        {
            print("Check true");
            isStairs = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Stairs"))
        {
            print("Check true");
            isStairs = false;

        }
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool isStair()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, stairs);


        return raycastHit.collider != null;
    }
    private bool isWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);


        return raycastHit.collider != null;
    }
    private void EnableMovement()
    {
        canMove = true;
    }
    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !isWall();
    }
}

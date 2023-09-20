
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
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    [SerializeField]private int SPEED;

    
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
        
       
        if (horizontalInput > 0.01f) { 
            transform.localScale = new Vector3(2,2,2);
        }else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded()){
          
            Jump();
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
     
    }

   



    private void OnCollisionEnter2D(Collision2D collision)
    { 
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        
       
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

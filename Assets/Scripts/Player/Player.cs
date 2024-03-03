using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float groundCheckDistance;

    [SerializeField] private float sideWallCheckDistance;

    [SerializeField] private bool isGrounded;

    private Animator animator;
    private bool canDoubleJump = true;

    private bool canMove;
    private bool canWallSlide;
    private int facingDirection = 1;
    private bool facingRight = true;

    private bool isMoving;
    private bool isWallDetected;
    private bool isWallSliding;

    private float movingInput;

    private Rigidbody2D playerRb;


    // Start is called before the first frame update
    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        UpdateAnimation();
        InputChecks();
        JumpPlayer();

        if (isGrounded) {
            canDoubleJump = true;
            canMove = true;
        }

        if (canWallSlide) {
            isWallSliding = true;
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * 0.1f);
            // canMove = false;
        }

        FlipController();

        Move();
    }

    private void FixedUpdate() {
        CollisionChecks();
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position,
            new Vector2(transform.position.x, transform.position.y - groundCheckDistance));
        Gizmos.DrawLine(transform.position,
            new Vector2(transform.position.x + sideWallCheckDistance * facingDirection, transform.position.y));
    }

    private void CollisionChecks() {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isWallDetected = Physics2D.Raycast(transform.position, Vector2.right * facingDirection, sideWallCheckDistance,
            groundLayer);
        if (isWallDetected && playerRb.velocity.y < -.1f) canWallSlide = true;

        if (!isWallDetected) {
            canWallSlide = false;
            isWallSliding = false;
        }
    }

    private void Jump() {
        playerRb.velocityY = jumpForce;
    }

    private void WallJump() {
        playerRb.velocity = new Vector2(5 * -facingDirection, jumpForce);
    }


    private void Flip() {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void FlipController() {
        if (facingRight && playerRb.velocity.x < -.1f)
            Flip();
        else if (!facingRight && playerRb.velocity.x > 0.1f) Flip();
    }

    private void JumpPlayer() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isWallSliding) {
                WallJump();
                canMove = false;
            }
            else if (isGrounded) {
                Jump();
            }
            else if (canDoubleJump) {
                Jump();
                canDoubleJump = false;
            }

            canWallSlide = false;
        }
    }

    private void Move() {
        if (canMove) playerRb.velocityX = movingInput * moveSpeed;
    }

    private void InputChecks() {
        if (Input.GetAxis("Vertical") < 0) canWallSlide = false;

        movingInput = Input.GetAxisRaw("Horizontal");
    }


    private void UpdateAnimation() {
        HorizontalMoveCheck();
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", playerRb.velocity.y);
        animator.SetBool("isWallSliding", isWallSliding);
        animator.SetBool("isWallDetected", isWallDetected);
    }

    private void HorizontalMoveCheck() {
        if (playerRb.velocity.x < -.1f || playerRb.velocity.x > .1f)
            isMoving = true;
        else
            isMoving = false;
    }
}
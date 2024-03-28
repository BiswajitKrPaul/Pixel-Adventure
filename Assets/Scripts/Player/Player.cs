using Constants;
using UnityEngine;

namespace Player {
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
        private void Awake() {
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
                var velocity = playerRb.velocity;
                velocity = new Vector2(velocity.x, velocity.y * 0.1f);
                playerRb.velocity = velocity;
                // canMove = false;
            }

            FlipController();

            Move();
        }

        private void FixedUpdate() {
            CollisionChecks();
        }

        private void OnDrawGizmos() {
            var position = transform.position;
            Gizmos.DrawLine(position,
                new Vector2(position.x, position.y - groundCheckDistance));
            Gizmos.DrawLine(position,
                new Vector2(position.x + sideWallCheckDistance * facingDirection, position.y));
        }

        private void CollisionChecks() {
            var position = transform.position;
            isGrounded = Physics2D.Raycast(position, Vector2.down, groundCheckDistance, groundLayer);
            isWallDetected = Physics2D.Raycast(position, Vector2.right * facingDirection, sideWallCheckDistance,
                groundLayer);
            switch (isWallDetected) {
                case true when playerRb.velocity.y < -.1f:
                    canWallSlide = true;
                    break;
                case false:
                    canWallSlide = false;
                    isWallSliding = false;
                    break;
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
            if (!Input.GetKeyDown(KeyCode.Space)) return;
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

        private void Move() {
            if (canMove) playerRb.velocityX = movingInput * moveSpeed;
        }

        private void InputChecks() {
            if (Input.GetAxis("Vertical") < 0) canWallSlide = false;

            movingInput = Input.GetAxisRaw("Horizontal");
        }


        private void UpdateAnimation() {
            HorizontalMoveCheck();
            animator.SetBool(StringConstants.IsMoving, isMoving);
            animator.SetBool(StringConstants.IsGrounded, isGrounded);
            animator.SetFloat(StringConstants.YVelocity, playerRb.velocity.y);
            animator.SetBool(StringConstants.IsWallSliding, isWallSliding);
            animator.SetBool(StringConstants.IsWallDetected, isWallDetected);
        }

        private void HorizontalMoveCheck() {
            isMoving = playerRb.velocity.x is < -.1f or > .1f;
        }
    }
}
using Constants;
using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerController : MonoBehaviour {
        [Header("Player States")] public PlayerMoveState playerMoveState;
        public PlayerIdleState playerIdleState;
        public PlayerStateMachine stateMachine;
        public PlayerJumpState playerJumpState;
        public PlayerAirState playerAirState;


        [Header("Player GameObjects")] public Rigidbody2D playerRb;
        public Animator animator;
        public LayerMask groundLayerMask;
        public float groundCheckDistance;
        public Transform groundCheck;


        private float facingDirection = 1f;
        private bool facingRight = true;

        private void Awake() {
            playerIdleState.SetUp(this, stateMachine, StringConstants.Idle);
            playerMoveState.SetUp(this, stateMachine, StringConstants.Move);
            playerJumpState.SetUp(this, stateMachine, StringConstants.Jump);
            playerAirState.SetUp(this, stateMachine, StringConstants.Jump);
        }

        private void Start() {
            stateMachine.Initialise(playerIdleState);
        }

        private void Update() {
            stateMachine.CurrentState.UpdateStatePerFrame();
        }


        private void OnGUI() {
            GUILayout.BeginArea(new Rect(10f, 10f, 400f, 100f));
            var content = stateMachine.CurrentState.name;
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
            GUILayout.EndArea();
        }

        private void OnDrawGizmos() {
            var position = groundCheck.transform.position;
            Gizmos.DrawLine(position, new Vector3(position.x, position.y - groundCheckDistance));
        }

        private void Flip() {
            facingDirection *= -1;
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }

        private void FlipController() {
            switch (playerRb.velocityX) {
                case < -0.1f when facingRight:
                case > 0.1f when !facingRight:
                    Flip();
                    break;
            }
        }

        public void SetVelocity(float xVelocity, float yVelocity) {
            playerRb.velocity = new Vector2(xVelocity, yVelocity);
            FlipController();
        }

        public bool IsOnFloor() {
            var isOnFloor = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance,
                groundLayerMask);
            return isOnFloor;
        }
    }
}
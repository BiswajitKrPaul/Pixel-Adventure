using Constants;
using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerState : MonoBehaviour {
        private string animationBoolName;
        private PlayerController player;


        protected Rigidbody2D rb;
        protected PlayerStateMachine stateMachine;
        protected float xInput;
        protected float yInput;

        protected PlayerIdleState IdleState => player.playerIdleState;
        protected PlayerMoveState MoveState => player.playerMoveState;
        protected PlayerAirState AirState => player.playerAirState;
        protected PlayerJumpState JumpState => player.playerJumpState;
        protected PlayerDoubleJumpState DoubleJumpState => player.playerDoubleJumpState;
        protected PlayerWallSlideState WallSlideState => player.playerWallSlideState;
        protected PlayerWallJumpState WallJumpState => player.playerWallJumpState;

        protected bool IsOnFloor => player.IsOnFloor();

        protected bool IsWallDetected => player.IsWallDetected();
        protected float FacingDirection => player.facingDirection;

        public virtual void Enter() {
            rb = player.playerRb;
            player.animator.SetBool(animationBoolName, true);
        }

        public virtual void UpdateStatePerFrame() {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            player.animator.SetFloat(StringConstants.YVelocity, rb.velocity.y);
        }

        public virtual void Exit() {
            player.animator.SetBool(animationBoolName, false);
        }

        public void SetUp(PlayerController playerController, PlayerStateMachine playerStateMachine,
            string animBoolName) {
            player = playerController;
            stateMachine = playerStateMachine;
            animationBoolName = animBoolName;
        }

        protected void SetVelocity(float xVelocity, float yVelocity) {
            player.SetVelocity(xVelocity, yVelocity);
        }
    }
}
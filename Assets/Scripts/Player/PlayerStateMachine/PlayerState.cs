using Constants;
using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerState : MonoBehaviour {
        private string animationBoolName;
        private PlayerController player;


        protected Rigidbody2D PlayerRb;
        protected PlayerStateMachine StateMachine;
        protected float XInput;
        protected float YInput;

        protected PlayerIdleState IdleState => player.playerIdleState;
        protected PlayerMoveState MoveState => player.playerMoveState;
        protected PlayerAirState AirState => player.playerAirState;
        protected PlayerJumpState JumpState => player.playerJumpState;

        protected bool IsOnFloor => player.IsOnFloor();

        public virtual void Enter() {
            PlayerRb = player.playerRb;
            player.animator.SetBool(animationBoolName, true);
        }

        public virtual void UpdateStatePerFrame() {
            XInput = Input.GetAxisRaw("Horizontal");
            YInput = Input.GetAxisRaw("Vertical");
            player.animator.SetFloat(StringConstants.YVelocity, PlayerRb.velocity.y);
        }

        public virtual void Exit() {
            player.animator.SetBool(animationBoolName, false);
        }

        public void SetUp(PlayerController p, PlayerStateMachine sM, string animBoolName) {
            player = p;
            StateMachine = sM;
            animationBoolName = animBoolName;
        }

        protected void SetVelocity(float xVelocity, float yVelocity) {
            player.SetVelocity(xVelocity, yVelocity);
        }
    }
}
using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerWallSlideState : PlayerState {
        public float wallSlideFriction;
        public Vector2 wallJumpForce;

        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (!IsWallDetected) StateMachine.ChangeState(AirState);
            if (Input.GetKeyDown(KeyCode.Space)) {
                SetVelocity(wallJumpForce.x * -FacingDirection, wallJumpForce.y);
                StateMachine.ChangeState(AirState);
                return;
            }

            if (YInput < 0)
                SetVelocity(0, PlayerRb.velocityY);
            else
                SetVelocity(0, PlayerRb.velocityY * wallSlideFriction);
            if (IsOnFloor) StateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
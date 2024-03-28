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
            if (!IsWallDetected) stateMachine.ChangeState(AirState);
            if (Input.GetKeyDown(KeyCode.Space)) {
                SetVelocity(wallJumpForce.x * -FacingDirection, wallJumpForce.y);
                stateMachine.ChangeState(AirState);
                return;
            }

            if (yInput < 0)
                SetVelocity(0, rb.velocityY);
            else
                SetVelocity(0, rb.velocityY * wallSlideFriction);
            if (IsOnFloor) stateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
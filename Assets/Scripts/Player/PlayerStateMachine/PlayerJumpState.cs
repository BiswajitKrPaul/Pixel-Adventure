﻿namespace Player.PlayerStateMachine {
    public class PlayerJumpState : PlayerState {
        public float jumpForce;

        public override void Enter() {
            base.Enter();
            SetVelocity(rb.velocityX, jumpForce);
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (!IsOnFloor) stateMachine.ChangeState(AirState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
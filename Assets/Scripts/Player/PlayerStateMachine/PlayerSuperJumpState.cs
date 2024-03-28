namespace Player.PlayerStateMachine {
    public class PlayerSuperJumpState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (IsOnFloor) stateMachine.ChangeState(IdleState);
            if (IsWallDetected && !IsOnFloor) stateMachine.ChangeState(WallSlideState);
            // if (XInput != 0) SetVelocity(8 * XInput, PlayerRb.velocityY);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
namespace Player.PlayerStateMachine {
    public class PlayerWallJumpState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (IsWallDetected) stateMachine.ChangeState(WallSlideState);

            if (IsOnFloor) stateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
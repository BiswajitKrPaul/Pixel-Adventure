namespace Player.PlayerStateMachine {
    public class PlayerWallJumpState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (IsWallDetected) StateMachine.ChangeState(WallSlideState);

            if (IsOnFloor) StateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
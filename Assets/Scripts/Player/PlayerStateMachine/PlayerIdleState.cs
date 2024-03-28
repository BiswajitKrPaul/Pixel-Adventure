namespace Player.PlayerStateMachine {
    public class PlayerIdleState : PlayerGroundState {
        public override void Enter() {
            base.Enter();
            SetVelocity(0, 0);
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (xInput != 0 && IsOnFloor) stateMachine.ChangeState(MoveState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
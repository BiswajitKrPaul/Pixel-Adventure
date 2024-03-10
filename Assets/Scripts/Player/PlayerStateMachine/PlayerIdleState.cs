namespace Player.PlayerStateMachine {
    public class PlayerIdleState : PlayerGroundState {
        public override void Enter() {
            base.Enter();
            SetVelocity(0, 0);
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (XInput != 0) StateMachine.ChangeState(MoveState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
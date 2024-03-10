namespace Player.PlayerStateMachine {
    public class PlayerAirState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (IsOnFloor) StateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
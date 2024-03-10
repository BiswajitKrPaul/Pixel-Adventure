namespace Player.PlayerStateMachine {
    public class PlayerJumpState : PlayerState {
        public float jumpForce;

        public override void Enter() {
            base.Enter();
            SetVelocity(PlayerRb.velocityX, jumpForce);
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (PlayerRb.velocityY < 0) StateMachine.ChangeState(AirState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
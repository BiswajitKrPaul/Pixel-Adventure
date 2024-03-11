namespace Player.PlayerStateMachine {
    public class PlayerDoubleJumpState : PlayerSuperJumpState {
        public float doubleJumpForce;

        public override void Enter() {
            base.Enter();
            SetVelocity(PlayerRb.velocityX, doubleJumpForce);
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
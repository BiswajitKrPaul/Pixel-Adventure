using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerAirState : PlayerSuperJumpState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (Input.GetKeyDown(KeyCode.Space)) stateMachine.ChangeState(DoubleJumpState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
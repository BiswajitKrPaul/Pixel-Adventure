using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerGroundState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (Input.GetKeyDown(KeyCode.Space)) stateMachine.ChangeState(JumpState);
            if (!IsOnFloor) stateMachine.ChangeState(AirState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
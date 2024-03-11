using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerGroundState : PlayerState {
        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            if (Input.GetKeyDown(KeyCode.Space)) StateMachine.ChangeState(JumpState);
            if (!IsOnFloor) StateMachine.ChangeState(AirState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
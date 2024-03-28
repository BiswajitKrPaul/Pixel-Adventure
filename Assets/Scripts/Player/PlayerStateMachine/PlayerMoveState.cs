using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerMoveState : PlayerGroundState {
        [SerializeField] private float moveSpeed;

        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            SetVelocity(moveSpeed * xInput, rb.velocityY);
            if (xInput == 0 && IsOnFloor) stateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
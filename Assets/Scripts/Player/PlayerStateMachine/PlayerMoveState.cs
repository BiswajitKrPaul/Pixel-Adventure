using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerMoveState : PlayerGroundState {
        [SerializeField] private float moveSpeed;

        public override void Enter() {
            base.Enter();
        }

        public override void UpdateStatePerFrame() {
            base.UpdateStatePerFrame();
            SetVelocity(moveSpeed * XInput, PlayerRb.velocityY);
            if (XInput == 0) StateMachine.ChangeState(IdleState);
        }

        public override void Exit() {
            base.Exit();
        }
    }
}
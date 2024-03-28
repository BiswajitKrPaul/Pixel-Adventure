using UnityEngine;

namespace Player.PlayerStateMachine {
    public class PlayerStateMachine : MonoBehaviour {
        public PlayerState CurrentState { get; private set; }


        public void Initialise(PlayerState newState) {
            CurrentState = newState;
            CurrentState.Enter();
        }

        public void ChangeState(PlayerState newState) {
            CurrentState.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}
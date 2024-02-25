using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM {

    [CreateAssetMenu(menuName = "FSM/Actions/Idle")]
    public class IdleAction : FSMAction
    {
        public override void Execute(BaseStateMachine stateMachine) {
            var dialogue = stateMachine.GetComponent<UnityEngine.AI.NavMeshAgent>();
            //dialogue.setActive(true);
        }
    }
}

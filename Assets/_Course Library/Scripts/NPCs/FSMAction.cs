using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public abstract class FSMAction : ScriptableObject
    {
       public abstract void Execute(BaseStateMachine machine);
    }
}

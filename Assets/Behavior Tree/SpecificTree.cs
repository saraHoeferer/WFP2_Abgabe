using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using System;

public class WaitPatrol : Node
{
   private Transform _transform;
   private String _dialoge;

   public WaitPatrol(Transform transform, String dialgoe){
        _transform = transform;
        _dialoge = dialgoe;
   }

    public override NodeState Evalute()
    {
        _dialoge = "Hello";
        state = NodeState.RUNNING;
        return state;
    }
}

public class GuardBT: BehaviorTree.Tree {
    public String dialgoe;

    protected override Node SetupTree()
    {
        Node root = new WaitPatrol(transform, dialgoe);
        return root;
    }
}

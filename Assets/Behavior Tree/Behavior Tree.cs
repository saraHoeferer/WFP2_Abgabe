using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BehaviorTree
{

    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
        protected NodeState state;

        public Node parent;
        protected List<Node> children = new List<Node>();

        public Node()
        {
            parent = null;
        }

        public Node(List<Node> children1)
        {
            foreach (Node child in children1)
            {
                _Attach(child);
            }
        }

        private void _Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evalute() => NodeState.FAILURE;

        private Dictionary<string, object> _dataContext = new Dictionary<string, object>();

        public void setData(string key, object value)
        {
            _dataContext[key] = value;
        }

        public object GetData(string key)
        {
            object val = null;
            if (_dataContext.TryGetValue(key, out val))
            {
                return val;
            }

            Node node = parent;

            if (node != null)
            {
                val = node.GetData(key);
            }

            return val;
        }


        public bool ClearData(string key)
        {
            bool cleared = false;
            if (_dataContext.ContainsKey(key))
            {
                _dataContext.Remove(key);
                return true;
            }

            Node node = parent;

            if (node != null)
            {
                cleared = node.ClearData(key);
            }


            return cleared;
        }
    }

    public abstract class Tree: MonoBehaviour {
        private Node _root = null;

        protected void Start() {
            _root = SetupTree();
        }

        private void Update() {
            if (_root != null) {
                _root.Evalute();
            }
        }

        protected abstract Node SetupTree();
    }

     public class Sequence : Node
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evalute()
        {
             bool anyChildIsRunning = false;

            foreach (Node node in children)
            {
                switch (node.Evalute())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;
                    case NodeState.SUCCESS:
                        continue;
                    case NodeState.RUNNING:
                        anyChildIsRunning = true;
                        continue;
                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }

            state = anyChildIsRunning ? NodeState.RUNNING : NodeState.SUCCESS;
            return state;
        }
    }

     public class Selector : Node
    {
        public Selector() : base() { }
        public Selector(List<Node> children) : base(children) { }

        public override NodeState Evalute()
        {
            foreach (Node node in children)
            {
                switch (node.Evalute())
                {
                    case NodeState.FAILURE:
                        continue;
                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS;
                        return state;
                    case NodeState.RUNNING:
                        state = NodeState.RUNNING;
                        return state;
                    default:
                        continue;
                }
            }

            state = NodeState.FAILURE;
            return state;
        }

    }
}
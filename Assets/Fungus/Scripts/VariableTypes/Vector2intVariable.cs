// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections;

namespace Fungus
{
    /// <summary>
    /// Vector2int variable type.
    /// </summary>
    [VariableInfo("Other", "Vector2Int")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class Vector2IntVariable : VariableBase<Vector2Int>
    {
        public static readonly CompareOperator[] compareOperators = { CompareOperator.Equals, CompareOperator.NotEquals };
        public static readonly SetOperator[] setOperators = { SetOperator.Assign, SetOperator.Add, SetOperator.Subtract };

        public virtual bool Evaluate(CompareOperator compareOperator, Vector2Int value)
        {
            bool condition = false;

            switch (compareOperator)
            {
                case CompareOperator.Equals:
                    condition = Value == value;
                    break;
                case CompareOperator.NotEquals:
                    condition = Value != value;
                    break;
                default:
                    Debug.LogError("The " + compareOperator.ToString() + " comparison operator is not valid.");
                    break;
            }

            return condition;
        }
        public virtual bool Evaluate(CompareOperator compareOperator, IntegerVariable value, Vector2field field)
        {
            bool condition = false;
            if (field == Vector2field.x)
            {
                switch (compareOperator)
                {
                    case CompareOperator.Equals:
                        condition = Value.x == value.Value;
                        break;
                    case CompareOperator.NotEquals:
                        condition = Value.x != value.Value;
                        break;
                    case CompareOperator.LessThan:
                        condition = Value.x < value.Value;
                        break;
                    case CompareOperator.GreaterThan:
                        condition = Value.x > value.Value;
                        break;
                    case CompareOperator.LessThanOrEquals:
                        condition = Value.x <= value.Value;
                        break;
                    case CompareOperator.GreaterThanOrEquals:
                        condition = Value.x >= value.Value;
                        break;
                    default:
                        Debug.LogError("The " + compareOperator.ToString() + " comparison operator is not valid.");
                        break;
                }
            }
            else if (field == Vector2field.y)
            {
                switch (compareOperator)
                {
                    case CompareOperator.Equals:
                        condition = Value.y == value.Value;
                        break;
                    case CompareOperator.NotEquals:
                        condition = Value.y != value.Value;
                        break;
                    case CompareOperator.LessThan:
                        condition = Value.y < value.Value;
                        break;
                    case CompareOperator.GreaterThan:
                        condition = Value.y > value.Value;
                        break;
                    case CompareOperator.LessThanOrEquals:
                        condition = Value.y <= value.Value;
                        break;
                    case CompareOperator.GreaterThanOrEquals:
                        condition = Value.y >= value.Value;
                        break;
                    default:
                        Debug.LogError("The " + compareOperator.ToString() + " comparison operator is not valid.");
                        break;
                }
            }
            return condition;

        }

        public override void Apply(SetOperator setOperator, Vector2Int value)
        {
            switch (setOperator)
            {
                case SetOperator.Assign:
                    Value = value;
                    break;
                case SetOperator.Add:
                    Value += value;
                    break;
                case SetOperator.Subtract:
                    Value -= value;
                    break;
                default:
                    Debug.LogError("The " + setOperator.ToString() + " set operator is not valid.");
                    break;
            }
        }
        
    }

    /// <summary>
    /// Container for a Vector2Int variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct Vector2IntData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(Vector2IntVariable))]
        public Vector2IntVariable vector2IntRef;
        
        [SerializeField]
        public Vector2Int vector2IntVal;

        public Vector2IntData(Vector2Int v)
        {
            vector2IntVal = v;
            vector2IntRef = null;
        }
        
        public static implicit operator Vector2Int(Vector2IntData vector2IntData)
        {
            return vector2IntData.Value;
        }

        public Vector2Int Value
        {
            get { return (vector2IntRef == null) ? vector2IntVal : vector2IntRef.Value; }
            set { if (vector2IntRef == null) { vector2IntVal = value; } else { vector2IntRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (vector2IntRef == null)
            {
                return vector2IntVal.ToString();
            }
            else
            {
                return vector2IntRef.Key;
            }
        }
    }
}
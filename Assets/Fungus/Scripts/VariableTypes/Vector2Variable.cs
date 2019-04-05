// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections;

namespace Fungus
{
    /// <summary>
    /// Vector2 variable type.
    /// </summary>
    [VariableInfo("Other", "Vector2")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class Vector2Variable : VariableBase<Vector2>
    {
        public static readonly CompareOperator[] compareOperators = { CompareOperator.Equals, CompareOperator.NotEquals };
        public static readonly SetOperator[] setOperators = { SetOperator.Assign, SetOperator.Add, SetOperator.Subtract };

        public virtual bool Evaluate(CompareOperator compareOperator, Vector2 value)
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
        public virtual bool Evaluate(CompareOperator compareOperator, FloatVariable value, Vector2field field)
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

        public override void Apply(SetOperator setOperator, Vector2 value)
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
    /// Container for a Vector2 variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct Vector2Data
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(Vector2Variable))]
        public Vector2Variable vector2Ref;
        
        [SerializeField]
        public Vector2 vector2Val;

        public Vector2Data(Vector2 v)
        {
            vector2Val = v;
            vector2Ref = null;
        }
        
        public static implicit operator Vector2(Vector2Data vector2Data)
        {
            return vector2Data.Value;
        }

        public Vector2 Value
        {
            get { return (vector2Ref == null) ? vector2Val : vector2Ref.Value; }
            set { if (vector2Ref == null) { vector2Val = value; } else { vector2Ref.Value = value; } }
        }

        public string GetDescription()
        {
            if (vector2Ref == null)
            {
                return vector2Val.ToString();
            }
            else
            {
                return vector2Ref.Key;
            }
        }
    }
}
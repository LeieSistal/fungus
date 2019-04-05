// This code is part of the Fungus library (http://fungusgames.com) maintained by Chris Gregan (http://twitter.com/gofungus).
// It is released for free under the MIT open source license (https://github.com/snozbot/fungus/blob/master/LICENSE)

using UnityEngine;
using System.Collections;

namespace Fungus
{
    /// <summary>
    /// Vector3Int variable type.
    /// </summary>
    [VariableInfo("Other", "Vector3Int")]
    [AddComponentMenu("")]
    [System.Serializable]
    public class Vector3IntVariable : VariableBase<Vector3Int>
    {
        public static readonly CompareOperator[] compareOperators = { CompareOperator.Equals, CompareOperator.NotEquals };
        public static readonly SetOperator[] setOperators = { SetOperator.Assign, SetOperator.Add, SetOperator.Subtract };

        public virtual bool Evaluate(CompareOperator compareOperator, Vector3Int value)
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
        public virtual bool Evaluate(CompareOperator compareOperator, IntegerVariable value, Vector3field field)
        {
            bool condition = false;
            if (field == Vector3field.x)
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
            else if (field == Vector3field.y)
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
            else if (field == Vector3field.z)
            {
                switch (compareOperator)
                {
                    case CompareOperator.Equals:
                        condition = Value.z == value.Value;
                        break;
                    case CompareOperator.NotEquals:
                        condition = Value.z != value.Value;
                        break;
                    case CompareOperator.LessThan:
                        condition = Value.z < value.Value;
                        break;
                    case CompareOperator.GreaterThan:
                        condition = Value.z > value.Value;
                        break;
                    case CompareOperator.LessThanOrEquals:
                        condition = Value.z <= value.Value;
                        break;
                    case CompareOperator.GreaterThanOrEquals:
                        condition = Value.z >= value.Value;
                        break;
                    default:
                        Debug.LogError("The " + compareOperator.ToString() + " comparison operator is not valid.");
                        break;
                }
            }
            return condition;

        }
        public override void Apply(SetOperator setOperator, Vector3Int value)
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
    /// Container for a Vector3Int variable reference or constant value.
    /// </summary>
    [System.Serializable]
    public struct Vector3IntData
    {
        [SerializeField]
        [VariableProperty("<Value>", typeof(Vector3IntVariable))]
        public Vector3IntVariable vector3IntRef;
        
        [SerializeField]
        public Vector3Int vector3IntVal;

        public Vector3IntData(Vector3Int v)
        {
            vector3IntVal = v;
            vector3IntRef = null;
        }
        
        public static implicit operator Vector3Int(Vector3IntData vector3IntData)
        {
            return vector3IntData.Value;
        }

        public Vector3Int Value
        {
            get { return (vector3IntRef == null) ? vector3IntVal : vector3IntRef.Value; }
            set { if (vector3IntRef == null) { vector3IntVal = value; } else { vector3IntRef.Value = value; } }
        }

        public string GetDescription()
        {
            if (vector3IntRef == null)
            {
                return vector3IntVal.ToString();
            }
            else
            {
                return vector3IntRef.Key;
            }
        }
    }
}
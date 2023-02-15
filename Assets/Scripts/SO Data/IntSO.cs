using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class IntSO : ScriptableObject
{
    [SerializeField] private int _value;
    [SerializeField] private int maxVal;
    public int Value
    {
        get { return _value; }
        set { _value = Mathf.Clamp(value, -1 ,maxVal); }
    }
}

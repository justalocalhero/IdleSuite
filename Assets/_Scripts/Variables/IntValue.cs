using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntValue", menuName = "IdleSuite/IntValue", order = 0)]
public class IntValue : ScriptableObject 
{
    public int _value;
    public int Value {
        get 
        { return _value; }
        set 
        {
            int dif = value - _value;
            _value = value;
            if(onValueSet != null) onValueSet(_value);
            if(onValueChanged != null) onValueChanged(dif);
            if(onChanged != null) onChanged();
        }
    }
    
    public delegate void OnValueSet(int value);
    public OnValueSet onValueSet;

    public delegate void OnValueChanged(int dif);
    public OnValueChanged onValueChanged;

    public delegate void OnChanged();
    public OnChanged onChanged;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "IdleSuite/Resource", order = 0)]
public class Resource : ScriptableObject 
{
    [SerializeField] private int initialValue;
    private int _value;
    public int lifeTimeValue {get; private set;}
    public int Value 
    { 
        get 
        { 
            return _value; 
        } 
        set 
        {
            int dif = value - _value;
            if(dif > 0) lifeTimeValue += dif;
            _value = value;
            if(onValueSet != null) onValueSet(_value);
        }
    }

    public delegate void OnValueSet(int value);
    public OnValueSet onValueSet;

    public void ResetResource()
    {
        lifeTimeValue = 0;
        _value = 0;
        Value = initialValue;
    }

    public void Refund(int toRefund)
    {
        _value += toRefund;
        if(onValueSet != null) onValueSet(_value);

    }
    
}

[System.Serializable]
public struct ResourceValue
{
    public Resource resource;
    public int value;
}
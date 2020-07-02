using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Resource", menuName = "IdleSuite/Resource", order = 0)]
public class Resource : ScriptableObject 
{
    public delegate void OnValueSet(int value);
    public OnValueSet onValueSet;

    public delegate void OnValueChanged(int dif);
    public OnValueChanged onValueChanged;

    public delegate void OnReservedSet(int value);
    public OnReservedSet onReservedSet;

    public delegate void OnReservedChanged(int dif);
    public OnReservedChanged onReservedChanged;

    public delegate void OnMaximumSet(int value);
    public OnMaximumSet onMaximumSet;

    public delegate void OnMaximumChanged(int dif);
    public OnMaximumChanged onMaximumChanged;

    public delegate void OnChanged();
    public OnChanged onChanged;



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
            int clampedValue = Mathf.Clamp(value, int.MinValue, Maximum);
            int dif = clampedValue - _value;

            if(dif > 0) lifeTimeValue += dif;
            _value = clampedValue;

            if(onValueSet != null) onValueSet(_value);
            if(onValueChanged != null) onValueChanged(dif);
            if(onChanged != null) onChanged();
        }
    }

    private int _reserved;
    public int Reserved
    {
        get
        {
            return _reserved;
        }
        set
        {
            int dif = value - _reserved;
            _reserved = value;
            
            if(onReservedSet != null) onReservedSet(_value);
            if(onReservedChanged != null) onReservedChanged(dif);
            if(onChanged != null) onChanged();

        }
    }

    
    public int Free { get { return Value - Reserved; } }
    public int Space { get { return Maximum - Value; } }

    [SerializeField] private int initialMaximum;
    private int _maximum;
    public int Maximum
    {
        get
        {
            return _maximum;
        }
        set
        {
            int dif = value - _maximum;
            _maximum = value;

            if(Value > Maximum) Value = Maximum;
            
            if(onMaximumSet != null) onMaximumSet(_value);
            if(onMaximumChanged != null) onMaximumChanged(dif);
            if(onChanged != null) onChanged();

        }
    }

    public void ResetResource()
    {
        lifeTimeValue = 0;
        _value = 0;
        _reserved = 0;
        _maximum = initialMaximum;
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


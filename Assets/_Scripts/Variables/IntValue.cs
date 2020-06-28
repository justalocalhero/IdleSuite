using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IntValue", menuName = "IdleSuite/IntValue", order = 0)]
public class IntValue : ScriptableObject 
{
    public int value {get; private set;}
    
    public delegate void OnChanged(int value);
    public OnChanged onChanged;

    public void Change(int value)
    {
        this.value = value;
        if(onChanged != null) onChanged(value);
    }
}

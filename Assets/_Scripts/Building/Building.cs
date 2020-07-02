using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : HeirarchyNode
{
    private int count;
    public int Count 
    {
        get 
        { 
            return count; 
        } 
        set 
        { 
            int dif = value - count;
            count = value;

            if(onCountChanged != null) onCountChanged(dif);
            if(onCountSet != null) onCountSet(count);
        }
    }

    public delegate void OnCountChanged(int change);
    public OnCountChanged onCountChanged;

    public delegate void OnCountSet(int value);
    public OnCountSet onCountSet;
}
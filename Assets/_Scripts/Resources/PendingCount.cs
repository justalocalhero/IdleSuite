using UnityEngine;

public class PendingCount : ScriptableObject 
{
    private int _pending;
    public int Pending 
    {
        get 
        { 
            return _pending; 
        } 
        set 
        { 
            int dif = value - _pending;
            _pending = value;

            if(onPendingChanged != null) onPendingChanged(dif);
            if(onPendingSet != null) onPendingSet(_pending);
            if(onChanged != null) onChanged();
        }
    }

    public delegate void OnPendingChanged(int change);
    public OnPendingChanged onPendingChanged;

    public delegate void OnPendingSet(int value);
    public OnPendingSet onPendingSet;

    public delegate void OnChanged();
    public OnChanged onChanged;


    private int _count;
    public int Count 
    {
        get 
        { 
            return _count; 
        } 
        set 
        { 
            int dif = value - _count;
            _count = value;

            if(onCountChanged != null) onCountChanged(dif);
            if(onCountSet != null) onCountSet(_count);
            if(onChanged != null) onChanged();
        }
    }

    public delegate void OnCountChanged(int change);
    public OnCountChanged onCountChanged;

    public delegate void OnCountSet(int value);
    public OnCountSet onCountSet;

    public void ResetBuilding()
    {
        _count = 0;
        _pending = 0;
    }
}
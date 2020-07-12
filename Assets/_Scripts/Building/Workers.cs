using UnityEngine;

public class Workers : MonoBehaviour
{
    private BuildingCount buildingCount;
    public int workersPerBuilding;
    public int Max { get { return buildingCount.Count * workersPerBuilding; } }
    public int Prefer { get; private set; }
    private int _value;
    public int Value 
    {
        get 
        { 
            return _value; 
        }
        set 
        { 
            int dif = value - _value;
            _value = value;

            if(dif != 0 && onChanged != null) onChanged();
        }
    }

    public delegate void OnChanged();
    public OnChanged onChanged;
    
    void Awake()
    {
        buildingCount = GetComponentInParent<Building>().buildingCount;
        buildingCount.onChanged += FauxSet;
    }

    void Start()
    {
        WorkerManager.instance.Register(this);
    }

    void FauxSet()
    {
        Set(Max);
    }

    void Set(int value)
    {
        Prefer = value;
        if(onChanged != null) onChanged();
    }
}
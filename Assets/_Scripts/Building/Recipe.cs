using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour, IFirable
{
    private Building building;

    public event OnFire onFire;

    void Start()
    {
        building = GetComponentInParent<Building>();
    }
    
    public void Fire() 
    {
        if(onFire != null) onFire();
    }
}

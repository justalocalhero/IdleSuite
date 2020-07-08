using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float timeScale;
    
    void Start()
    {
        Time.timeScale = timeScale;        
    }

    void OnValidate()
    {
        Time.timeScale = timeScale;
    }
}
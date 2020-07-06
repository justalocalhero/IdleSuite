using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseValueManager : MonoBehaviour
{
    public IntValue purchaseCount;

    private void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            purchaseCount.Value = 10;
        }

        else if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            purchaseCount.Value = 100;
        }
        else
        {
            purchaseCount.Value = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MultiplierChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (PartMover part in GetComponentsInChildren<PartMover>())
        {
            part._multiplier /= 2; 
        }
    }
}

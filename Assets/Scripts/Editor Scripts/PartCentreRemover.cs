using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PartCentreRemover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var part in GetComponentsInChildren<PartMover>())
        {
            if (part.transform.childCount >= 1)
                DestroyImmediate(part.transform.GetChild(0).gameObject);
        }
    }
}

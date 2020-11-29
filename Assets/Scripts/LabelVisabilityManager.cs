using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelVisabilityManager : MonoBehaviour
{
    private MeshRenderer _partRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _partRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_partRenderer.isVisible)
        //    GetComponent<MeshRenderer>().enabled = true;
        //else
        //    GetComponent<MeshRenderer>().enabled = false;
    }
}
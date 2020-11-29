using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModelExpander : MonoBehaviour
{
    [SerializeField]
    private Transform _centerTran;
    
    private bool _isExpanded = false;
    
    public void OnMouseDown()
    {
        foreach (PartMover part in GetComponentsInChildren<PartMover>())
        {
            if (_isExpanded)
                StartCoroutine(part.ReturnPos());
            else
                StartCoroutine(part.ExpandPos(_centerTran.position));
        }
        _isExpanded = !_isExpanded;
    }
}

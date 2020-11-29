using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RotationUpdator : MonoBehaviour
{    
    private Transform _model;

    void Start()
    {
        ModelManager.onModelChange.AddListener(SetModel);
    }

    private void SetModel(GameObject newModel)
    {
        _model = newModel.transform;
    }

    public void SetModelRotation()
    {
        float newRotation = GetComponent<Slider>().value;
        _model.localEulerAngles = new Vector3(_model.localEulerAngles.x, newRotation, _model.localEulerAngles.z);
    }
}
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class RotationUpdator : MonoBehaviour
{
    [SerializeField]
    private Transform _model;
    public void SetModelRotation()
    {
        float newRotation = GetComponent<Slider>().value;
        _model.localEulerAngles = new Vector3(_model.localEulerAngles.x, newRotation, _model.localEulerAngles.z);
    }
}
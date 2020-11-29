using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ScaleUpdator : MonoBehaviour
{
    [SerializeField]
    private Transform _model;

    public void SetModelScale()
    {
        float newScale = GetComponent<Slider>().value;
        _model.localScale = new Vector3(newScale, newScale, newScale);
    }
}
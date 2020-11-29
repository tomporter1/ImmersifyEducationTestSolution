using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ScaleUpdator : MonoBehaviour
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

    public void SetModelScale()
    {
        float newScale = GetComponent<Slider>().value;
        _model.localScale = new Vector3(newScale, newScale, newScale);
    }
}
using TMPro;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField]
    private GameObject _labelPrefab;

    private TextMeshPro _labelText;
    private static readonly float labelMultiplier = 0.5f;

    public Vector3 CentreOfMass { get => GetComponent<Renderer>().bounds.center; }

    public void InstantiateLabel(Vector3 modelCentre)
    {
        GameObject newLabel = Instantiate(_labelPrefab, transform);
        _labelText = newLabel.GetComponent<TextMeshPro>();
        _labelText.text = "";

        //Set label position
        Vector3 offsetDirection = CentreOfMass - modelCentre;
        Vector3 labelPosition = offsetDirection + CentreOfMass * labelMultiplier;
        _labelText.transform.position = labelPosition;
    }    

    internal void ReturnPosition(Vector3 modelCentre)
    {
        StartCoroutine(GetComponent<PartMover>().ExpandPos(modelCentre));
    }

    internal void Expand()
    {
        StartCoroutine(GetComponent<PartMover>().ReturnPos());
    }

    public void SetLabelText(string newText)
    {
        if (_labelText != null)
            _labelText.text = newText;
    }
}
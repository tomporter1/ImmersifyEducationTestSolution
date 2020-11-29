using TMPro;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField]
    private GameObject _labelPrefab;

    private TextMeshPro _labelText;

    public Vector3 CentreOfMass { get => GetComponent<Renderer>().bounds.center; }

    public void InstantiateLabel()
    {
        GameObject newLabel = Instantiate(_labelPrefab, transform);
        _labelText = newLabel.GetComponent<TextMeshPro>();
        _labelText.text = "";

        //Set label position
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

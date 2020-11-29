using TMPro;
using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField]
    private GameObject _labelPrefab;

    private TextMeshPro _labelText;
    private static readonly float labelMultiplier = 0.85f;

    public Vector3 CentreOfMass { get => GetComponent<Renderer>().bounds.center; }
    public MeshRenderer Renderer { get => GetComponent<MeshRenderer>(); }

    public void InstantiateLabel(Vector3 modelCentre)
    {
        GameObject newLabel = Instantiate(_labelPrefab, transform);
        _labelText = newLabel.GetComponent<TextMeshPro>();
        _labelText.text = "";

        //Set label position

        Vector3 offsetDirection = CentreOfMass - modelCentre;
        Vector3 labelPosition = offsetDirection + CentreOfMass * labelMultiplier;

        //set label position
        _labelText.transform.position = labelPosition;
    }

    //public void DrawLineToLabel()
    //{
    //    gameObject.AddComponent<LineRenderer>();
    //    LineRenderer line = GetComponent<LineRenderer>();
    //    line.useWorldSpace = false;
    //    line.startWidth = 0.02f;
    //    line.endWidth = 0.02f;
    //    Vector3[] positions = new Vector3[2] { _labelText.transform.position, CentreOfMass };
    //    line.SetPositions(positions);
    //}

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

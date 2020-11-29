using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Part : MonoBehaviour
{
    [SerializeField]
    private GameObject _labelPrefab;

    private TextMeshPro _labelText;

    public void InstantiateLabel()
    {
        GameObject newLabel = Instantiate(_labelPrefab, transform);
        _labelText = newLabel.GetComponent<TextMeshPro>();
        _labelText.text = "";
    }

    public void SetLabelText(string newText)
    {
        if (_labelText != null)
            _labelText.text = newText;
    }
}

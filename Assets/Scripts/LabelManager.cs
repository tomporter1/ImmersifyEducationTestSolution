using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
    [SerializeField]
    private Transform _modelCentre;

    public bool _labelsAreVisable { get; private set; }
    private static string RemoveNonLetterChars(string input) => Regex.Replace(input, "[._ 1234567890()\r\b]", "").ToLower();

    // Start is called before the first frame update
    void Start()
    {
        AddLabelsToParts();

        SetLabelsText();

        SetLabelsVisability(false);
    }

    public void ToggelLabelVisability()
    {
        if (GetComponentInChildren<MeshRenderer>().enabled)
        {
            if (_labelsAreVisable)
                SetLabelsVisability(false);
            else
                SetLabelsVisability(true);
        }
    }

    private void AddLabelsToParts()
    {
        foreach (Part part in GetComponentsInChildren<Part>(true))
        {
            part.InstantiateLabel(_modelCentre.position);
        }
    }

    private void SetLabelsText()
    {
        List<string> labels = LabelLoader.GetLabelData();

        foreach (Part part in GetComponentsInChildren<Part>(true))
        {
            SetLabelText(part.transform, part, labels);
        }
    }

    private void SetLabelText(Transform obj, Part part, List<string> labels)
    {
        string simplifiedObjName = RemoveNonLetterChars(obj.name);
        string labelText = labels.Where(l => RemoveNonLetterChars(l).Contains(simplifiedObjName)).FirstOrDefault();

        if (labelText != null)
            part.SetLabelText(labelText);
        else if(obj.transform.parent != null)
            SetLabelText(obj.transform.parent, part, labels);
    }
    private void SetLabelsVisability(bool isActive)
    {
        foreach (TextMeshPro tmp in GetComponentsInChildren<TextMeshPro>(true))
        {
            tmp.gameObject.SetActive(isActive);
        }
        _labelsAreVisable = isActive;
    }
}

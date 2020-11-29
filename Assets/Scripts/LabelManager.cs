using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
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
        if (_labelsAreVisable)
            SetLabelsVisability(false);
        else
            SetLabelsVisability(true);
    }

    private void AddLabelsToParts()
    {
        foreach (Part part in GetComponentsInChildren<Part>(true))
        {
            part.InstantiateLabel();
        }
    }

    private void SetLabelsText()
    {
        List<string> labels = LabelLoader.GetLabelData();

        foreach (Part part in GetComponentsInChildren<Part>(true))
        {
            string partName = part.name;
            partName = RemoveNonLetterChars(partName);

            foreach (string lab in labels)
            {
                if (RemoveNonLetterChars(lab).Contains(partName))
                    part.SetLabelText(lab);
            }
        }
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

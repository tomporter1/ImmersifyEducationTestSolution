using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLabelUpdater : MonoBehaviour
{
    [SerializeField]
    private LabelManager _labelManager;

    public void SetButtonText() => GetComponentInChildren<Text>().text = _labelManager._labelsAreVisable ? "Hide Part Labels" : "Show Part Labels";

    void Start()
    {
        SetButtonText();
    }
}

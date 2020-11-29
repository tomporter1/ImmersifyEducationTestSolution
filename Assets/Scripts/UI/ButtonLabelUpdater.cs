using UnityEngine;
using UnityEngine.UI;

public class ButtonLabelUpdater : MonoBehaviour
{
    private LabelManager _labelManager;

    void Start()
    {
        ModelManager.onModelChange.AddListener(SetModel);
        SetButtonText();
    }

    public void SetButtonText()
    {
        if (_labelManager != null)
        {
            GetComponentInChildren<Text>().text = _labelManager._labelsAreVisable ? "Hide Part Labels" : "Show Part Labels";
            _labelManager.ToggelLabelVisability();
        }
    }

    private void SetModel(GameObject newModel)
    {
        _labelManager = newModel.GetComponent<LabelManager>();
        SetButtonText();
    }
}
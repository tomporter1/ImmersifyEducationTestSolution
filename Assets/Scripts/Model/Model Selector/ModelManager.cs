using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnModelChange : UnityEvent<GameObject> { }

[RequireComponent(typeof(Dropdown))]
public class ModelManager : MonoBehaviour
{
    public static OnModelChange onModelChange = new OnModelChange();
    [SerializeField]
    private List<GameObject> models;
    [SerializeField]
    private Transform _modelParent;
    private Dropdown _modelDropdown;

    // Start is called before the first frame update
    void Start()
    {
        _modelDropdown = GetComponent<Dropdown>();

        _modelDropdown.ClearOptions();

        List<Dropdown.OptionData> options = new List<Dropdown.OptionData>();
        foreach (GameObject model in models)
        {
            options.Add(new Dropdown.OptionData(model.name));
        }
        
        _modelDropdown.AddOptions(options);
        
        ChangeModel();
    }

    public void ChangeModel()
    {
        //remove the old model
        foreach (Transform child in _modelParent)
        {
            GameObject.Destroy(child.gameObject);
        }

        //display the new one
        GameObject selectedModel = models[_modelDropdown.value];
        GameObject newModel = Instantiate(selectedModel, _modelParent);

        onModelChange.Invoke(newModel);
    }
}
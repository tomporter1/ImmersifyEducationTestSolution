using UnityEngine;

public class ModelExpander : MonoBehaviour
{
    [SerializeField]
    private Transform _centerTran;
    
    private bool _isExpanded = false;
    
    public void OnMouseDown()
    {
        foreach (Part part in GetComponentsInChildren<Part>())
        {
            if (_isExpanded)
                part.Expand();
            else
                part.ReturnPosition(_centerTran.position); 
        }
        _isExpanded = !_isExpanded;
    }
}
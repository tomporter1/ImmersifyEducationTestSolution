using UnityEngine;

[ExecuteInEditMode]
public class AddPartMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(MeshRenderer part in GetComponentsInChildren<MeshRenderer>())
        {
            part.gameObject.AddComponent<PartMover>();
        }
    }
}

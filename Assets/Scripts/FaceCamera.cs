using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private static Transform _cam;

    void Start()
    {
        _cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _cam.rotation;
    }
}

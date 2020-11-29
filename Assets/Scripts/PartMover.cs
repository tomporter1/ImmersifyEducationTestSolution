using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Part))]
public class PartMover : MonoBehaviour
{
    [SerializeField]
    private Transform _directionMarker;
    [SerializeField, Range(0.001f, 1.5f)]
    internal float _multiplier;

    private Vector3 _origionalPos;
    private Vector3 partCentre { get => GetComponent<Part>().CentreOfMass; }
    private Vector3 directionPoint { get => _directionMarker == null ? partCentre : _directionMarker.position; }

    private static float _moveTime = 1f;

    /// <summary>
    /// Sends the part away from the model centre. 
    /// The distance it goes is dependant on the multiplier.
    /// The object will go in the direction of _directionMarker from the object centre.
    /// </summary>
    /// <param name="modelCentre">The centre of the whole model</param>
    internal IEnumerator ExpandPos(Vector3 modelCentre)
    {
        _origionalPos = transform.position;

        //calculate end position
        Vector3 offset = transform.position - partCentre;
        Vector3 expandDirection = directionPoint - modelCentre;
        Vector3 endPos = partCentre - offset + expandDirection * _multiplier;

        Vector3 startPos = transform.position;
        float elapsedTime = 0;

        while (elapsedTime < _moveTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / _moveTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = endPos;
    }

    /// <summary>
    /// Sends the part back to its origional position before expansion
    /// </summary>
    internal IEnumerator ReturnPos()
    {
        Vector3 endPos = _origionalPos != null ? _origionalPos : transform.position;
        Vector3 startPos = transform.position;

        float elapsedTime = 0;

        while (elapsedTime < _moveTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / _moveTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = endPos;
    }
}
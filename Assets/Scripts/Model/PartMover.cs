using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Part))]
public class PartMover : MonoBehaviour
{
    [SerializeField]
    private bool _isMovable = true;
    [SerializeField, Tooltip("The object that marks the direction that this part will go in")]
    private Transform _directionMarker;
    [SerializeField, Range(0.001f, 1.5f), Tooltip("How far the part is moved out form the centre in the expanded view")]
    internal float _multiplier;

    private Vector3 _origionalLocalPos;
    private Vector3 _partCentre { get => GetComponent<Part>().CentreOfMass; }
    private Vector3 _directionPoint { get => _directionMarker == null ? _partCentre : _directionMarker.position; }

    private static float _moveTime = 1f;

    /// <summary>
    /// Sends the part away from the model centre. 
    /// The distance it goes is dependant on the multiplier.
    /// The object will go in the direction of _directionMarker from the object centre.
    /// </summary>
    /// <param name="modelCentre">The centre of the whole model</param>
    internal IEnumerator ExpandPos(Vector3 modelCentre)
    {      
        //Save the origional position to return to after
        _origionalLocalPos = transform.localPosition;

        //calculate end position
        Vector3 offset = transform.position - _partCentre;
        Vector3 expandDirection = _directionPoint - modelCentre;
        Vector3 endPos = _partCentre - offset + expandDirection * _multiplier;

        Vector3 startPos = transform.position;
        float elapsedTime = 0;

        while (_isMovable && elapsedTime < _moveTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / _moveTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }

    /// <summary>
    /// Sends the part back to its origional position before expansion
    /// </summary>
    internal IEnumerator ReturnPos()
    {
        Vector3 endPos = _origionalLocalPos != null ? _origionalLocalPos : transform.localPosition;
        Vector3 startPos = transform.localPosition;

        float elapsedTime = 0;

        while (_isMovable && elapsedTime < _moveTime)
        {
            transform.localPosition = Vector3.Lerp(startPos, endPos, (elapsedTime / _moveTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }
}
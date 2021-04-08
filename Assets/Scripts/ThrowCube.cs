using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
    [Header("Cached References")]

    [SerializeField] private Camera otoCam;
    [SerializeField] private LineControl lc;

    [Header("Drag Settings")]

    [SerializeField] private float power = 10f;
    [SerializeField] private Vector3 minPower;
    [SerializeField] private Vector3 maxPower;

    // Target game object.

    [CanBeNull] private GameObject _targetGO;

    // Local private variables.

    private Vector3 _force;
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private Ray _ray;
    private RaycastHit _hit;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.collider.gameObject.tag == "Parts")
                { 
                    _targetGO = _hit.collider.gameObject;

                    //Debug.Log("Hit");

                }

            }

            if (_targetGO != null)
            {
                _startPoint = _targetGO.transform.position;

                _startPoint.y = 2f;

            }
            
        }

        if (Input.GetMouseButton(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                Vector3 currentPoint = _hit.point;

                currentPoint.y = 2f;

                if (_targetGO != null)
                {
                    lc.RenderLine(_startPoint, currentPoint);

                    //Debug.Log("Current end point? : " + currentPoint);

                }

            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                _endPoint = _hit.point;

                _endPoint.y = 1f;

                _force = new Vector3(Mathf.Clamp(_startPoint.x - _endPoint.x, minPower.x, maxPower.x), 0, Mathf.Clamp(_startPoint.z - _endPoint.z, minPower.z, maxPower.z));

                if (_targetGO != null)
                {
                    _targetGO.GetComponent<Rigidbody>().AddForce(_force * power, ForceMode.Impulse);
                    _targetGO = null;

                }

                lc.EndLine();

            }

        }

    }

}

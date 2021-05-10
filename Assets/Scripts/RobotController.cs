using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    private List<Transform> _transformChilds = new List<Transform>();
    public GameObject partical;
    private void Start()
    {
        foreach (Transform child in transform)
        {
            _transformChilds.Add(child);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Parts"))
        {
            var _currentPartTranform = other.transform;

            Debug.Log("Current hit part : " + _currentPartTranform);

            for (int x = 0; x < _transformChilds.Count; x++)
            {
                if (_transformChilds[x].tag == _currentPartTranform.GetChild(0).tag)
                {
                    Debug.Log("Correct Match Part");

                    _currentPartTranform.GetComponent<Rigidbody>().velocity = Vector3.zero;

                    _currentPartTranform.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

                    _currentPartTranform.GetComponent<Collider>().isTrigger = true;

                    _currentPartTranform.GetComponent<Collider>().enabled = false;
                    
                    _currentPartTranform.localRotation = Quaternion.Euler(_currentPartTranform.GetComponent<PartsController>().endPartEulerX, _currentPartTranform.GetComponent<PartsController>().endPartEulerY, _currentPartTranform.GetComponent<PartsController>().endPartEulerZ);

                    _currentPartTranform.localPosition = _transformChilds[x].position;

                    Instantiate(partical, _transformChilds[x].transform.position,
                        _transformChilds[x].transform.rotation);



                }
            }

        }

    }
}

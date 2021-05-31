﻿using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ThrowCube : MonoBehaviour
{
    [Header("Cached References")]

    [SerializeField] private Camera otoCam;
    [SerializeField] private LineControl lc;
    [SerializeField] private Text TurnsText;

    [SerializeField] private RobotController robotController;
    private SceneMan sceneMan;

    [Header("Drag Settings")]

    [SerializeField] private float power = 10f;
    [SerializeField] private Vector3 minPower;
    [SerializeField] private Vector3 maxPower;

    [SerializeField] int NumberOfTurns;


    // Target game object.

    [CanBeNull] private GameObject _targetGO;

    [SerializeField] private WaitBetweenActions waitBetweenActions;

    // Local private variables.

    private Vector3 _force;
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private Ray _ray;
    private RaycastHit _hit;

    void Start()
    {
        TurnsText.text = NumberOfTurns.ToString();
        sceneMan = new SceneMan();
    }

    void Update()
    {
        Throw();
    }

    void Throw()
    {
        if (waitBetweenActions.CanThrow)
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

                    //currentPoint.y = 0.2f;  // this is the y value of the line // if we want it to be with a little offset and not go threw gm`s

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

                    _force = new Vector3(Mathf.Clamp(_startPoint.x - _endPoint.x, minPower.x, maxPower.x), 0,
                        Mathf.Clamp(_startPoint.z - _endPoint.z, minPower.z, maxPower.z));

                    if (_targetGO != null)
                    {
                        _targetGO.GetComponent<Rigidbody>().AddForce(_force * power, ForceMode.Impulse);
                        NumberOfTurns--; // this is where the turns goes down 1 turn
                        StartCoroutine(TurnsCheck());
                        TurnsText.text = NumberOfTurns.ToString();
                        Debug.Log(NumberOfTurns);
                        _targetGO = null;
                    }
                    lc.EndLine();
                }
            }
        }
    }

    IEnumerator TurnsCheck()
    {
        yield return new WaitForSeconds(3f);
        if (robotController.isRobotFull)
        {
            Debug.Log("You Won!");
        }
        else if(NumberOfTurns <= 0)
        {
            sceneMan.SceneRestart(); // window of "You lost"
        }
    }

}

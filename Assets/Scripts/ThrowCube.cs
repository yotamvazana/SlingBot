using System.Collections;
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
    [SerializeField] private GameUIManager gameUIManager;
    private SceneMan sceneMan;

    [Header("Drag Settings")]

    [SerializeField] private float power = 2f;
    [Tooltip("y equals to 0 at all times")]
    [SerializeField] private Vector3 minPower;
    [Tooltip("y equals to 0 at all times")]
    [SerializeField] private Vector3 maxPower;

    [SerializeField] int NumberOfTurns;
    [SerializeField] private List<GameObject> currentPart;

    // Target game object.
    [SerializeField] private WaitBetweenActions waitBetweenActions;

    [Header("Visuals")]

    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private GameObject arrowPowerPrefab;
    [SerializeField] private ParticleSystem highlight;
    [SerializeField] private arrow2DMaskScript arrowMaskSC;

    // Local private variables.

    private Vector3 _awayFromScreen = new Vector3(55f, 55f, 55f);
    private Vector3 _force;
    private Vector3 _startPoint;
    private Vector3 _endPoint;

    private Ray _ray;
    private RaycastHit _hit;

    void Start()
    {
        highlight = Instantiate(highlight, _awayFromScreen, highlight.transform.rotation);
        arrowPowerPrefab = Instantiate(arrowPowerPrefab, _awayFromScreen, Quaternion.identity);
        arrowPrefab = Instantiate(arrowPrefab, _awayFromScreen, Quaternion.identity);
        arrowMaskSC = arrowPrefab.GetComponentInChildren<arrow2DMaskScript>();
        
        TurnsText.text = NumberOfTurns.ToString();
        sceneMan = new SceneMan();
    }

    void Update()
    {
        Throw();
        if (currentPart.Count >= 1)
        {
            if (Input.GetMouseButton(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit))
                {
                    Vector3 currentPoint = _hit.point;
                    currentPoint.y = 0.2f;  // this is the y value of the line // if we want it to be with a little offset and not go threw gm`s
                    Vector3 arrowRotation = _startPoint - currentPoint;

                    arrowRotation.y = 0;

                    arrowRotation.x = Mathf.Clamp(arrowRotation.x, -7, 7);

                    arrowRotation.z = Mathf.Clamp(arrowRotation.z, -7, 7);

                    arrowPrefab.transform.position = new Vector3(currentPart[0].transform.position.x, currentPart[0].transform.position.y + 0.5f, currentPart[0].transform.position.z);
                    arrowPrefab.transform.rotation = Quaternion.LookRotation(arrowRotation);

                    arrowPowerPrefab.transform.rotation = Quaternion.LookRotation(arrowRotation);
                    arrowPowerPrefab.transform.position = arrowPrefab.transform.position;

                    arrowPrefab.transform.position += arrowPrefab.transform.forward; // circle motion

                    arrowPowerPrefab.transform.position += Vector3.ClampMagnitude(arrowRotation, 7); // circle motion + max strength

                    Debug.Log("Arrow rot: " + arrowRotation);

                    //Debug.Log("Clamp Magnitude: " + Vector3.ClampMagnitude(arrowRotation, 7));

                    var OldRange = (7 - -7);
                    var NewRange = (1f - -1);
                    var NewValue = (((arrowRotation.x - -7) * NewRange) / OldRange) + -1;
                    var NewValue2 = (((arrowRotation.z - -7) * NewRange) / OldRange) + -1;

                    Debug.Log("New ValueX: " + NewValue);

                    Debug.Log("New ValueZ: " + NewValue2);

                    if (NewValue > 0)
                    {
                        NewValue *= -1;
                    }

                    if (NewValue2 > 0)
                    {
                        NewValue2 *= -1;
                    }

                    Debug.Log("New ValueX: " + NewValue);

                    Debug.Log("New ValueZ: " + NewValue2);

                    if (NewValue < NewValue2)
                    {
                        arrowMaskSC.SetSpriteOffset(NewValue);

                    }
                    else if (NewValue > NewValue2)
                    {
                        arrowMaskSC.SetSpriteOffset(NewValue2);

                    }
                    else
                    {
                        arrowMaskSC.SetSpriteOffset(NewValue2);
                    }

                    //var convertedLength = arrowRotation

                }
            }
        }

        void Throw()
        {

            if (Input.GetMouseButtonDown(0)) // only for start point
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(_ray, out _hit))
                {
                    _startPoint = _hit.point;

                    _startPoint.y = 2f;
                }
            }


            if (waitBetweenActions.CanThrow)
            {
                if (Input.GetMouseButtonUp(0))
                {
                    arrowPowerPrefab.transform.position = _awayFromScreen; // remove from vision
                    arrowPrefab.transform.position = _awayFromScreen; // remove from vision

                    _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(_ray, out _hit))
                    {
                        _endPoint = _hit.point;

                        _endPoint.y = 1f;

                        _force = new Vector3(Mathf.Clamp(_startPoint.x - _endPoint.x, minPower.x, maxPower.x), 0,
                            Mathf.Clamp(_startPoint.z - _endPoint.z, minPower.z, maxPower.z));


                        if (currentPart.Count >= 1 && _hit.collider.gameObject.tag != "Parts")
                        {
                            currentPart[0].GetComponent<Rigidbody>().AddForce(_force * power, ForceMode.Impulse);
                            // highlight.Stop();
                            currentPart[0].transform.GetComponent<Outline>().OutlineWidth = 1f;
                            NumberOfTurns--; // this is where the turns goes down 1 turn
                            currentPart.Clear();
                            StartCoroutine(TurnsCheck());
                            TurnsText.text = NumberOfTurns.ToString();
                        }

                        if (_hit.collider.gameObject.tag == "Parts")
                        {
                            if (currentPart.Count > 0)
                            {
                                currentPart[0].transform.GetComponent<Outline>().OutlineWidth = 1f;

                            }
                            currentPart.Clear();
                            currentPart.Add(_hit.collider.gameObject);
                            // highlight.transform.position = currentPart[0].transform.position;
                            // highlight.Play();
                            currentPart[0].transform.GetComponent<Outline>().OutlineWidth = 4f;
                            // add a selected effect
                        }

                        lc.EndLine();

                    }
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

            gameUIManager.OnGameWin();

        }
        else if(NumberOfTurns <= 0)
        {
            //sceneMan.SceneRestart(); // window of "You lost"

            gameUIManager.OnGameLost();

        }
    }

}

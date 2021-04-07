using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody rb;

    public Vector3 minPower;
    public Vector3 maxPower;
    private Camera cam;
    public Camera otoCam;

    public LineControl lc;

    private Vector3 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {
        cam = Camera.main;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = otoCam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.y = 1f;
            Debug.Log(startPoint);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = otoCam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.y = 1f;
            lc.RenderLine(startPoint , currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = otoCam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.y = 1f;
            force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x,minPower.x,maxPower.x),0,Mathf.Clamp(startPoint.z - endPoint.z, minPower.z,maxPower.z));
            rb.AddForce(force * power,ForceMode.Impulse);
        }
    }

}

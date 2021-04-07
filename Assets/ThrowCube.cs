using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
    public float power = 10f;

    [CanBeNull] private GameObject Target;

    public Vector3 minPower;
    public Vector3 maxPower;
    public Camera otoCam;

    public LineControl lc;

    private Vector3 force;
    private Vector3 startPoint;
    private Vector3 endPoint;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.gameObject.tag == "Parts")
                { 
                    Target = hit.collider.gameObject;
                    Debug.Log("Hit");
                }
            }

            if (Target != null)
            {
                startPoint = Target.transform.position;
                startPoint.y = 1f;
            }
            
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = otoCam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.y = 1f;
            if (Target != null)
            {
                lc.RenderLine(startPoint, currentPoint);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPoint = otoCam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.y = 1f;
            force = new Vector3(Mathf.Clamp(startPoint.x - endPoint.x,minPower.x,maxPower.x),0,Mathf.Clamp(startPoint.z - endPoint.z, minPower.z,maxPower.z));
            if (Target != null)
            {
                Target.GetComponent<Rigidbody>().AddForce(force * power, ForceMode.Impulse);
                Target = null;
            }
            lc.EndLine();
        }
    }

}

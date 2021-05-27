using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    public float sawSpeed = 1;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(-Vector3.forward * sawSpeed);

    }

}

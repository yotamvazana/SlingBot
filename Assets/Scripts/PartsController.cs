using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    public float endPartEulerY;

    public float endPartEulerX;

    public float endPartEulerZ;


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Parts")
        {
            Debug.Log("You Lost Idiota");
        }


    }

}

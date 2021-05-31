using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    public float endPartEulerY;

    public float endPartEulerX;

    public float endPartEulerZ;

    private SceneMan _Sm;

    public float forceMultiplier;

    void Start()
    {
        _Sm = new SceneMan();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Parts")
        {
            StartCoroutine(LoseCond());

        }

        if (collision.gameObject.tag == "Saw")
        {
            Debug.Log("Collided Saw");

            Vector3 dir = collision.relativeVelocity;

            AddForceToPart(dir);

        }

    }

    private void AddForceToPart(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir.normalized * forceMultiplier);

    }

    IEnumerator LoseCond()
    {
        yield return new WaitForSeconds(1f);

        _Sm.SceneRestart();

    }

}

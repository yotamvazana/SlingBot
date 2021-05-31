using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class OilSpill : MonoBehaviour
{
    [SerializeField] private float power = 3;
    [CanBeNull]private Rigidbody rb;


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Parts")
        {
            rb = col.gameObject.GetComponent<Rigidbody>();
            rb.drag = 0;
            
            Vector3 dir = rb.velocity.normalized;
            rb.AddForce(dir * power * Time.deltaTime);
            
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Parts")
        {
            rb.drag = 2.5f;
            //rb = null;
        }
    }
}

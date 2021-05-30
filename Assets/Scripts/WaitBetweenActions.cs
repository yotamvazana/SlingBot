using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics.;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitBetweenActions : MonoBehaviour
{
    [Header("Parts")]
    [SerializeField] List<Rigidbody> rbList = new List<Rigidbody>();

    [CanBeNull] private Rigidbody movingRb;

    public bool CanThrow = true;

    void Start()
    {
        movingRb = new Rigidbody();
    }
    void Update()
    {
        foreach (var rb in rbList)
        {
            if (rb.velocity.magnitude > 0)
            {
                movingRb = rb;
                break;
            }
        }

        if (movingRb != null) 
        {
            if (movingRb.velocity.magnitude < 0.2)
            {
                CanThrow = true;
                movingRb = null;
            }
            else
            {
                CanThrow = false;
            }
        }
        

    }

}

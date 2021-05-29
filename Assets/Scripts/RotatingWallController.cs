using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingWallController : MonoBehaviour
{
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != pos)
        {
            transform.position = pos;

        }

    }
}

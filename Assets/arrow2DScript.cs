using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow2DScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().material.renderQueue = 5000;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

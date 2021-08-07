using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow2DMaskScript : MonoBehaviour
{
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = gameObject.GetComponent<SpriteRenderer>().material;

    }

    public void SetSpriteOffset(float offset)
    {
        mat.SetFloat("offsetY", offset);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

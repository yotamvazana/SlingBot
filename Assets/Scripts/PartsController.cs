using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsController : MonoBehaviour
{
    public float endPartEulerY;

    public float endPartEulerX;

    public float endPartEulerZ;

    private SceneMan _Sm;

    void Start()
    {
        _Sm = new SceneMan();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Parts")
        {
            _Sm.SceneRestart();
        }

        if (collision.gameObject.tag == "Traps")
        {
            _Sm.SceneRestart();
        }
    }

}

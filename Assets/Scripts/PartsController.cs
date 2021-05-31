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
            StartCoroutine(LoseCond());
        }

        if (collision.gameObject.tag == "Traps")
        {
            StartCoroutine(LoseCond());
        }
    }

    IEnumerator LoseCond()
    {
        yield return new WaitForSeconds(1f);
        _Sm.SceneRestart();
    }
}

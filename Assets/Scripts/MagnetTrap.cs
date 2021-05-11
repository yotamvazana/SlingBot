using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTrap : MonoBehaviour
{
    public float radius;
    [SerializeField] private float speed = 3;

    [SerializeField]List<Rigidbody> partList = new List<Rigidbody>();
    [SerializeField] private LayerMask part;

    [SerializeField] private GameObject magnetShader;

    void Start()
    {
        magnetShader.transform.localScale = Vector3.one * radius * 2;
        Instantiate(magnetShader, transform.position, transform.rotation);

    }
    void FixedUpdate()
    {
        if (GetMagnetPiece().Count >= 1)
        {
            foreach (Rigidbody tr in partList)
            {
                if (Vector3.Distance(tr.position,transform.position) > 0.8)
                {
                    Vector3 dir = transform.position - tr.position;
                    tr.MovePosition(tr.position + dir.normalized * speed * Time.deltaTime);
                }
            }
        }
        

    }

    List<Rigidbody> GetMagnetPiece()
    {
        partList.Clear();
        Collider[] partsInRadius = Physics.OverlapSphere(transform.position, radius,part);

        for (int i = 0; i < partsInRadius.Length; i++)
        {
            Rigidbody target = partsInRadius[i].gameObject.GetComponent<Rigidbody>();

            partList.Add(target);
        }
        return partList;

    }


}

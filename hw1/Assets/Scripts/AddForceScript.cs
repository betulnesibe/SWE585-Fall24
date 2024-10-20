using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceScript : MonoBehaviour
{

    public Rigidbody rb; // to make it publicly accessible
    public float force = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (rb== null) // if not added from ui
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(1, 0, 0) * force);
    }
}

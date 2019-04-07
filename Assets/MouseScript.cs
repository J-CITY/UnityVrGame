using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ray;

        if (Physics.Raycast(transform.position, transform.forward, out ray))
        {
            if (ray.collider != null)
            {

            }
        }
    }
}

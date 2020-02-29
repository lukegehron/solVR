using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMinAndMaxVals : MonoBehaviour
{

    Quaternion myStarting;
    // Start is called before the first frame update
    void Start()
    {
        myStarting = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 1.0759f) {
            transform.position = new Vector3(transform.position.x, 1.0759f, transform.position.z);
        } else if(transform.position.y > 1.548f)
        {
            transform.position = new Vector3(transform.position.x, 1.548f, transform.position.z);
        }
        transform.rotation = myStarting;
    }
}

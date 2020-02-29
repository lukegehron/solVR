using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepTableOnGround : MonoBehaviour
{
    // Start is called before the first frame update

    Quaternion myRot;
    Vector3 myPos;

    void Start()
    {
       myPos = gameObject.transform.position;
       myRot = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, myPos.y, transform.position.z);
        transform.rotation = Quaternion.Euler(myRot.eulerAngles.x, transform.rotation.eulerAngles.y, myRot.eulerAngles.z);

    }
}

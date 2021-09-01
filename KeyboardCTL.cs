using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardCTL : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform anoTracker;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveControl();
    }
    void MoveControl()

    {

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * 0.1f, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 center = (transform.position + anoTracker.position) / 2;
            transform.RotateAround(center,Vector3.up, 0.3f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(Vector3.up * -0.1f, Space.Self);
            Vector3 center = (transform.position + anoTracker.position) / 2;
            transform.RotateAround(center, Vector3.up, -0.3f);
        }

        if (Input.GetKey(KeyCode.Q))

        {

            transform.Rotate(Vector3.up, -3.0f);

        }

        if (Input.GetKey(KeyCode.E))

        {

            transform.Rotate(Vector3.up, 3.0f);

        }

        //transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

        //transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y"));

    }
}

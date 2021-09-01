using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkforward : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 lasfor;

    void Start()
    {
        lasfor = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpfor = transform.forward;
        if (tmpfor != lasfor)
        {
            Debug.Log("transforward:" + tmpfor);
            lasfor = tmpfor;
        }
    }
}

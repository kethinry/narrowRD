using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkQua : MonoBehaviour
{
    // Start is called before the first frame update
    public Quaternion lasRot;
    void Start()
    {
        lasRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion tmpROt = transform.rotation;
        if (tmpROt != lasRot)
        {
            Debug.Log("Quaternion.Inverse:" + Quaternion.Inverse(tmpROt));
            Debug.Log("transform.forwad" + transform.forward);
            Debug.Log("relative dir" + Quaternion.Inverse(tmpROt) * transform.forward);
            lasRot = tmpROt;
        }
    }
}

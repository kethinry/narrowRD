using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationRDW : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 lastDir;
    public Transform head;
    public Vector3 headfor;

    void Start()
    {
        //head = transform.Find("RealUser").Find("HMD");
        //lastPos = GetRelativePosition(head.position, this.transform);
        lastDir = Quaternion.Inverse(transform.rotation) * head.forward;
        headfor = head.forward;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmpDir;
        headfor = head.forward;

        //tempPos = GetRelativePosition(head.position, this.transform);
        tmpDir = Quaternion.Inverse(transform.rotation) * head.forward;
        float angle = Vector3.SignedAngle(lastDir, tmpDir, Vector3.up);
        //Debug.Log("POS" + tempPos.ToString("F3"));
        //Debug.Log("dis" + displacement.ToString("F3"));
        if (angle != 0)
            transform.Rotate(10 * Vector3.up * angle);
        lastDir = tmpDir;
    }
}

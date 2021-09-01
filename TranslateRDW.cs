using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateRDW : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 lastPos;
    public Transform head;
    public float teanslationScale=1.5f;

    //public static Vector3 GetRelativePosition(Vector3 pos, Transform origin)
    //{
    //    return Quaternion.Inverse(origin.rotation) * (pos - origin.position);
    //}

    void Start()
    {
        head = transform.Find("RealUser").Find("HMD");
        //lastPos = GetRelativePosition(head.position, this.transform);
        lastPos = head.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tempPos;

        //tempPos = GetRelativePosition(head.position, this.transform);
        tempPos = head.localPosition;
        Vector3 displacement = tempPos - lastPos;
        Debug.Log("POS" + tempPos.ToString("F3"));
        Debug.Log("dis" + displacement.ToString("F3"));
        if (displacement.magnitude > 0)
            transform.Translate(teanslationScale * displacement.x, 0, teanslationScale * displacement.z, Space.World);
        lastPos = tempPos;
    }
}

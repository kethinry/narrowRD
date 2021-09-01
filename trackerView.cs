using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackerView : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tracker1;
    public Transform tracker2;
    public Transform father;
    public Vector3 lastDir;


    void Start()
    {
        transform.position = (tracker1.position + tracker2.position) / 2;
        transform.position = new Vector3(transform.position.x,1.78f,transform.position.z);
        lastDir = Vector3.Normalize(Quaternion.Inverse(father.rotation) * tracker1.forward + Quaternion.Inverse(father.rotation) * tracker2.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (tracker1.position + tracker2.position) / 2;
        transform.position = new Vector3(transform.position.x, 1.78f, transform.position.z);
        Vector3 tmpDir = Vector3.Normalize(Quaternion.Inverse(father.rotation) * tracker1.forward + Quaternion.Inverse(father.rotation) * tracker2.forward);
        float angle = Vector3.SignedAngle(lastDir, tmpDir, Vector3.up);
        //if (tracker1.TransformDirection(tracker1.forward) == Quaternion.Inverse(father.rotation) * tracker1.forward)
        //    Debug.Log("Yes! They are equal!");
        //else
        //    Debug.Log("No! They are not equal...");
        if (angle != 0)
            transform.Rotate(Vector3.up * angle);
        lastDir = tmpDir;
    }
}

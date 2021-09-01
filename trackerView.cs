using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackerView : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform tracker1;
    public Transform tracker2;
    public Vector3 lastDir;


    void Start()
    {
        transform.position = (tracker1.position + tracker2.position) / 2;
        transform.position = new Vector3(transform.position.x,1.78f,transform.position.z);
        lastDir = Vector3.Normalize(tracker1.forward + tracker2.forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (tracker1.position + tracker2.position) / 2;
        transform.position = new Vector3(transform.position.x, 1.78f, transform.position.z);
        Vector3 tmpDir = Vector3.Normalize(tracker1.forward + tracker2.forward);
        float angle = Vector3.SignedAngle(lastDir, tmpDir, Vector3.up);
        if (angle != 0)
            transform.Rotate(Vector3.up * angle);
        lastDir = tmpDir;
    }
}

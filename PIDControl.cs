using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIDControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float LastErrorPos;
    public float LastErrorCosAngle;

    public float InterErrorPos;
    public float InterErrorCosAngle;

    public float LastGain;

    public Vector3 LastPos;
    public Vector3 LastVirtualPos;
    public Vector3 LastVirDir;
    public Vector3 LastRealDir;
    public float LastVRangle;
    public float k_p1 = -5f;
    public float k_p2 = -5f;
    public float k_i1 = -0.00f;
    public float k_i2 = -0.0f;
    public float k_d1 = 20f;
    public float k_d2 = 0f;
    // person in Real Space Axis
    public Transform person;
    void Start()
    {
        //Application.targetFrameRate = 1;
        LastPos = person.position;
        LastVRangle = 0;
        LastRealDir = person.TransformDirection(person.forward);
        LastVirDir = person.forward;
        LastErrorCosAngle = 0;
        LastErrorPos = 0;
        InterErrorPos = 0;
        InterErrorCosAngle = 0;
        LastGain = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float Virangle = CalVirangle(PID());
        Debug.Log("Virangle" + Virangle);
        Quaternion rot = Quaternion.Euler(0, Virangle, 0);
        Debug.Log("LastVirDir" + LastVirDir);
        Vector3 OrienVirDir = rot*LastVirDir;
        Debug.Log("OriDir" + OrienVirDir);
        LastVirDir = OrienVirDir;
        float rotangle = Vector3.SignedAngle(person.forward, OrienVirDir,Vector3.up);
        Debug.Log("rotangle" + rotangle);
        transform.Rotate(Vector3.up * rotangle);

    }
    float PID()
    {
        float ErrorPos = person.localPosition.z;
        float ErrorCosAngle = Vector3.Dot(person.forward, transform.right);
        Debug.Log("person:"+person.forward);
        Debug.Log("room:" + transform.right);
        InterErrorPos += ErrorPos;
        InterErrorCosAngle += ErrorCosAngle;
        float output = k_p1 * ErrorPos + k_p2 * ErrorCosAngle + k_i1 * InterErrorPos + k_i2 * InterErrorCosAngle + k_d1 * (ErrorPos - LastErrorPos) + k_d2 * (ErrorCosAngle - LastErrorCosAngle);
        LastErrorCosAngle = ErrorCosAngle;
        LastErrorPos = ErrorPos;
        float Gain = output * Time.deltaTime + LastGain;
        LastGain = Gain;
        return Gain;
    }
    //Calculate Direction changing angle in Virtual World
    float CalVirangle(float Gain)
    {
        Vector3 tmpRealDir = person.TransformDirection(person.forward);
        float RealChange = Vector3.SignedAngle(tmpRealDir,LastRealDir,Vector3.up);
        float VRangle = LastVRangle + Gain * Time.deltaTime;
        LastVRangle = VRangle;
        float Virangle = RealChange + VRangle;
        LastRealDir = tmpRealDir;
        return Virangle;
    }
}

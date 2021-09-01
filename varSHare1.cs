using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varSHare1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float x;
    void Start()
    {
        x = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        x = x + 1;
    }
}

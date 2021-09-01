using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class varSHare2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float y;
    public varSHare1 cube;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        y = cube.x;
    }
}

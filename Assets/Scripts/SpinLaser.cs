using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLaser : MonoBehaviour
{
    private float field_float_spinningVelocity = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, field_float_spinningVelocity * Time.deltaTime);
    }
}

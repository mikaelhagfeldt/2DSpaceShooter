using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad_BackgroundScriptLevel2 : MonoBehaviour
{
    private float field_float_scrollSpeed = 0.05f;
    private Material field_material;
    private Vector2 field_vector2;

    // Start is called before the first frame update
    void Start()
    {
        // Getting access to our Quad renderer.
        field_material = GetComponent<Renderer>().material;
        field_vector2 = new Vector2(0f, field_float_scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // Getting access to our background "offset".
        // Time.deltaTime is to make the scrolling "framerate independent".
        field_material.mainTextureOffset += field_vector2 * Time.deltaTime;
    }
}

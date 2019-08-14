using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRemoverWallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * When the laser hits our wall (box bollider attached to the gameobject), the laser prefab is destroyed.
     */ 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}

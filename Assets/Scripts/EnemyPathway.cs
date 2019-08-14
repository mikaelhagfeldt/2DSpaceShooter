using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathway : MonoBehaviour
{
    // SerializeField is used when you need to attach game objects to the inspector in unity.

    List<Transform> field_transform_passages;
    private int field_int_passagesIndex = 0;

    WaveControllerScript field_waveControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        field_transform_passages = field_waveControllerScript.getAllPassages();
        transform.position = field_transform_passages[field_int_passagesIndex].transform.position;
    }

    // Update is called once per frame

    /*
     * As long as there is another passage waiting to go to, the enemy unit will go through all passages. 
     * 
     * Basically, if we have valid movement (there is another passage to go through), execute code that helps us move.
     * Else the enemy was never shot down, destroy that game object. 
     * 
     * Consider extracting move function to a method?
     */

    void Update()
    {
        if (field_int_passagesIndex < field_transform_passages.Count)
        {
            var local_newPosition = field_transform_passages[field_int_passagesIndex].transform.position;
            var local_currentSpeedInThisFrame = field_waveControllerScript.getVelocity() * Time.deltaTime; // Making it frame rate independent, same on all computers.
            transform.position = Vector2.MoveTowards(transform.position, local_newPosition, local_currentSpeedInThisFrame);
            if (transform.position == local_newPosition)
            {
                field_int_passagesIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWaveController(WaveControllerScript p_waveControllerScript)
    {
        field_waveControllerScript = p_waveControllerScript;
    }
}

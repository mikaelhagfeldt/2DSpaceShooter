using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WaveController")]
public class WaveControllerScript : ScriptableObject
{
    [SerializeField] GameObject field_gameObject_enemy;
    [SerializeField] GameObject field_gameObject_pathway;
    [SerializeField] private float field_float_spawnInterval = 0.7f;
    [SerializeField] private float field_float_spawnRandomInterval = 0.23f;
    [SerializeField] private float field_float_velocity = 1.11f;
    [SerializeField] private int field_int_howManyEnemies = 4;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetEnemy()
    {
        return field_gameObject_enemy;
    }

    public List<Transform> getAllPassages()
    {
        var local_passages = new List<Transform>();
        foreach (Transform item in field_gameObject_pathway.transform)
        {
            local_passages.Add(item);
        }
        return local_passages;
    }

    public float getSpawnInterval()
    {
        return field_float_spawnInterval;
    }

    public float getSpawnRandomInterval()
    {
        return field_float_spawnRandomInterval;
    }

    public float getVelocity()
    {
        return field_float_velocity;
    }

    public int getHowManyEnemies()
    {
        return field_int_howManyEnemies;
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private int field_int_damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetFieldIntDamage()
    {
        return field_int_damage;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript2 : MonoBehaviour
{
    // With SerializeField we can change the health of individual enemy prefabs.
    // With SerializeField we can change the variables inside the Unity Editor.
    [SerializeField] private float field_float_health = 20;

    [SerializeField] private float field_float_laserCounter;
    [SerializeField] private float field_float_minimumLasershotFrequency = 0.5f;
    [SerializeField] private float field_float_maximumLaserShotFrequency = 3.5f;
    [SerializeField] private GameObject field_gameObject_enemyLaser;
    [SerializeField] private float field_float_enemyLaserVelocity = 7f;

    [SerializeField] private GameObject field_gameObject_deathAnimation;

    [SerializeField] private AudioClip field_audioClip_deathSound;
    [SerializeField] private float field_float_deathSoundVolume = 0.7f;

    [SerializeField] private AudioClip field_audioClip_hitSound;
    [SerializeField] private float field_float_hitSoundVolume = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        field_float_laserCounter = UnityEngine.Random.Range(field_float_minimumLasershotFrequency, field_float_maximumLaserShotFrequency);
    }

    // Update is called once per frame
    void Update()
    {
        AfterCountdownShootLaser();
    }

    private void AfterCountdownShootLaser()
    {
        field_float_laserCounter -= Time.deltaTime;
        if (field_float_laserCounter <= 0)
        {
            FireLaser();
            field_float_laserCounter = UnityEngine.Random.Range(field_float_minimumLasershotFrequency, field_float_maximumLaserShotFrequency);
        }
    }

    private void FireLaser()
    {
        GameObject local_enemyLaser = Instantiate(field_gameObject_enemyLaser, transform.position, Quaternion.identity) as GameObject; // Quaternion.identity = no rotation necessary
        local_enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -field_float_enemyLaserVelocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageScript local_damageScript = collision.gameObject.GetComponent<DamageScript>();
        field_float_health -= local_damageScript.GetFieldIntDamage();
        local_damageScript.Destroy();
        triggerHitSound();
        if (field_float_health <= 0)
        {
            Destroy(gameObject);
            triggerDeathAnimation();
            triggerDeathSound();
        }
    }

    private void triggerDeathAnimation()
    {
        GameObject local_gameObject = Instantiate(field_gameObject_deathAnimation, transform.position, transform.rotation);
    }

    private void triggerDeathSound()
    {
        AudioSource.PlayClipAtPoint(field_audioClip_deathSound, Camera.main.transform.position, field_float_deathSoundVolume);
    }

    private void triggerHitSound()
    {
        AudioSource.PlayClipAtPoint(field_audioClip_hitSound, Camera.main.transform.position, field_float_hitSoundVolume);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : MonoBehaviour
{
    // Variable to help us increase the speed of the game.
    private float field_movementVelocity = 6f;

    private float field_float_minimumXValue;
    private float field_float_maximumXValue;
    private float field_float_minimumYValue;
    private float field_float_maximumYValue;
    private float field_float_paddingValue = 0.19f;

    [SerializeField] GameObject field_gameobject_blueLaser;

    private float field_float_laserVelocity = 9f;
    private float field_float_laserFiringInterval = 0.12f;
    Coroutine field_coroutine_blueLaserFireCoroutine;

    [SerializeField] private int field_int_playerHealth = 50;
    [SerializeField] private double field_dob_playerHealthCopy = 50;
    private double field_dob_percentage = 100;

    [SerializeField] private GameObject field_gameObject_deathAnimation;

    [SerializeField] private AudioClip field_audioClip_deathSound;
    [SerializeField] private float field_float_deathSoundVolume = 0.7f;

    [SerializeField] private AudioClip field_audioClip_hitSound;
    [SerializeField] private float field_float_hitSoundVolume = 0.2f;

    [SerializeField] private AudioClip field_audioClip_humanLaserSound;
    [SerializeField] private float field_float_humanLaserSoundVolume = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        HumanPlayerMovementBoundaries();

    }

    /*
     * Configuring the standard boundaries for the human player of this game, saving them into variables.
     */ 

    private void HumanPlayerMovementBoundaries()
    {
        Camera local_camera = Camera.main;
        field_float_minimumXValue = local_camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        field_float_maximumXValue = local_camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        field_float_minimumYValue = local_camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        field_float_maximumYValue = local_camera.ViewportToWorldPoint(new Vector3(0, 0.6f, 0)).y;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHumanPlayer();
        HumanPlayerFireLaser();
    }

    /*
     * When the player presses down the "Fire1" key, the coroutine NeverEndingFireLaser() is triggered. 
     */

    private void HumanPlayerFireLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            field_coroutine_blueLaserFireCoroutine = StartCoroutine(NeverEndingFireLaser());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            // StopAllCoroutines(); In case of other coroutines this is a bad idea.
            StopCoroutine(field_coroutine_blueLaserFireCoroutine);
        }
    }

    /*
     * A coroutine is a method that can suspend specific execution of code, for example if certain parts of your code need to wait a few seconds
     * before execution takes place. A coroutine can be used in the same context to make sure that a certain action is always triggered if 
     * a certain condition is met, like holding down a button to fire a laser. The field_float_laserFiringInterval variable tells Unity how 
     * long it takes between each shot. 
     */

    IEnumerator NeverEndingFireLaser()
    {
        while (true)
        {
            // Instantiating the blue laser prefab where our humanplayer icon is.
            GameObject local_gameObject_blueLaser = Instantiate(field_gameobject_blueLaser, transform.position, Quaternion.identity) as GameObject;
            local_gameObject_blueLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, field_float_laserVelocity);
            triggerHumanLaserSound();
            yield return new WaitForSeconds(field_float_laserFiringInterval);
        }
    }

    /*
     * Using the variables from HumanPlayerMovementBoundaries(), changing the human players position.
     * 
     * Time.deltaTime is used to make your game "frame rate independent".
     * Meaning a faster computer screen does not equal a faster game speed.
     */

    private void MoveHumanPlayer()
    {
        var local_changedX = Input.GetAxis("Horizontal") * Time.deltaTime * field_movementVelocity;
        //Debug.Log(local_changedX);
        var local_newPlayerXPosition = Mathf.Clamp(transform.position.x + local_changedX, field_float_minimumXValue + field_float_paddingValue, field_float_maximumXValue - field_float_paddingValue);
        

        var local_changedY = Input.GetAxis("Vertical") * Time.deltaTime * field_movementVelocity;
        //Debug.Log(local_changedY);
        var local_newPlayerYPosition = Mathf.Clamp(transform.position.y + local_changedY, field_float_minimumYValue + field_float_paddingValue, field_float_maximumYValue - field_float_paddingValue);

        transform.position = new Vector2(local_newPlayerXPosition, local_newPlayerYPosition);
    }

    /*
     * Using the DamageScript class, when the enemy laser hits the player, its health will be reduced accordingly. When the 
     * players health reaches zero, the player game object is destroyed. If a gameobject collides with our player ship, 
     * that object will also be destroyed, like the laser. 
     * 
     * Null reference error here??
     */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageScript local_damageScript = collision.gameObject.GetComponent<DamageScript>();
        if (local_damageScript == false)
        {
            return;
        }

        field_int_playerHealth -= local_damageScript.GetFieldIntDamage();

        field_dob_percentage = (field_int_playerHealth) / (field_dob_playerHealthCopy) * 100;
        //Debug.Log(field_dob_percentage);

        local_damageScript.Destroy();
        triggerHitSound();

        if (field_int_playerHealth <= 0)
        {
            FindObjectOfType<LevelLoadingScript>().LoadGameOverScreen();
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

    private void triggerHumanLaserSound()
    {
        AudioSource.PlayClipAtPoint(field_audioClip_humanLaserSound, Camera.main.transform.position, field_float_humanLaserSoundVolume);
    }

    public int getPlayerHealth()
    {


        return field_int_playerHealth;
    }

    public void setPlayerHealthToZero()
    {
        field_int_playerHealth = 0;
    }

    public void DestroyPlayer()
    {
        Destroy(gameObject);
    }

    public double getPlayerPercentage()
    {
        return field_dob_percentage;
    }
}


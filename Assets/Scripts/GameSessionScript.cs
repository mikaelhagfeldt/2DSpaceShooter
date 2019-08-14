using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSessionScript : MonoBehaviour
{
    private int field_int_playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        SingleTonManagement();
    }

    /*
     * A SingleTon manager function makes sure that a gameobject remains between scenes (destroying replacements if there are any).
     * With that you can have a running score throughout your game, or if you wish, a constant loop of the same music track.
     */

    private void SingleTonManagement()
    {
        int local_int_numberOfGameSessions = FindObjectsOfType<GameSessionScript>().Length;
        if (local_int_numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetField_int_playerScore()
    {
        return field_int_playerScore;
    }

    public void AddScorePoints(int p_scorePoints)
    {
        field_int_playerScore += p_scorePoints;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}


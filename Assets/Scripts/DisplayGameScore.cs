using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGameScore : MonoBehaviour
{
    private Text field_text_scoreDisplay;
    private GameSessionScript field_gameSessionScript;

    // Start is called before the first frame update
    void Start()
    {
        field_text_scoreDisplay = GetComponent<Text>();
        field_gameSessionScript = FindObjectOfType<GameSessionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        field_text_scoreDisplay.text = field_gameSessionScript.GetField_int_playerScore().ToString();
    }
}

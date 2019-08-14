using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    private Text field_text_playerHealthDisplay;
    private HumanPlayer2 field_HumanPlayer;

    // Start is called before the first frame update
    void Start()
    {
        field_text_playerHealthDisplay = GetComponent<Text>();
        field_HumanPlayer = FindObjectOfType<HumanPlayer2>();
    }

    // Update is called once per frame
    void Update()
    {
        field_text_playerHealthDisplay.text = field_HumanPlayer.getPlayerPercentage().ToString();
    }
}


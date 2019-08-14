using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("MainGame");
        FindObjectOfType<GameSessionScript>().ResetGame();
    }

    public void LoadLevel2()
    {
        StartCoroutine(waitBeforeProgressingToLevel2());
    }

    public void LoadGameOverScreen()
    {
        StartCoroutine(waitBeforeDying());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator waitBeforeDying()
    {
        yield return new WaitForSeconds(2.4f);
        SceneManager.LoadScene("GameOver");
    }

    private IEnumerator waitBeforeProgressingToLevel2()
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Level2");
    }
}

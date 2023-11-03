using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : Menu
{
    public TMPro.TMP_Text headerText;
    public TMPro.TMP_Text bodyText;
    public GameObject background;

    public bool hasWon = false;

    protected void OnDisable()
    {
        background.SetActive(false);
    }

    protected void OnEnable()
    {
        background.SetActive(true);

        if (hasWon)
        {
            headerText.text = "Win";
            bodyText.text = "You won the game";
        } else
        {
            headerText.text = "Game Over";
            bodyText.text = "You lost the game (but not that one [actually I guess you did lose that one too now, sorry about that])";
        }
    }

    public void RestartButton()
    {
        Disable();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Simple Game");
    }

    public void QuitButton()
    {
        Disable();
        Application.Quit();
    }
}

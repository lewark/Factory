using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : Menu
{
    public TMPro.TMP_Text headerText;
    public TMPro.TMP_Text bodyText;
    public GameObject background;
    public RobotController player;
    public MusicPlayer musicPlayer;

    public bool hasWon = false;

    override protected void OnMenuHide()
    {
        background.SetActive(false);
    }

    override protected void OnMenuShow()
    {
        background.SetActive(true);

        if (hasWon)
        {
            musicPlayer.PlayTrack(1);
            headerText.text = "The End";
            bodyText.text = "";
        } else
        {
            musicPlayer.PlayTrack(-1);
            GetComponent<AudioSource>().Play();
            headerText.text = "Game Over";
            bodyText.text = "You lost the game (but not that one [actually I guess you did lose that one too now, sorry about that])";
        }
    }

    public void SetEndMessage(string endMessage)
    {
        bodyText.text = endMessage;
    }

    public void RestartButton()
    {
        Disable();
        if (hasWon)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Factory");
        }
        else
        {
            musicPlayer.PlayTrack(0);
            player.GoToCheckpoint();
        }
    }

    public void QuitButton()
    {
        Disable();
        Application.Quit();
    }
}

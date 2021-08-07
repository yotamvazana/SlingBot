using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuGamePanel;

    [SerializeField] GameObject resetPanel;

    [SerializeField] GameObject winPanel;

    [SerializeField] GameObject losePanel;

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;

        resetPanel.SetActive(true);

        pauseMenuGamePanel.SetActive(true);

        winPanel.SetActive(false);

        losePanel.SetActive(false);

    }

    public void OnClickResetPanel()
    {
        resetPanel.SetActive(false);

        pauseMenuGamePanel.SetActive(false);

        winPanel.SetActive(false);

        losePanel.SetActive(false);

        Time.timeScale = 1;
        
    }

    public void OnGameWin()
    {
        Time.timeScale = 0;

        resetPanel.SetActive(true);

        pauseMenuGamePanel.SetActive(false);

        winPanel.SetActive(true);

        losePanel.SetActive(false);

    }

    public void OnGameLost()
    {
        Time.timeScale = 0;

        resetPanel.SetActive(true);

        pauseMenuGamePanel.SetActive(false);

        winPanel.SetActive(false);

        losePanel.SetActive(true);

    }

    public void OnClickMainMenuButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(0);

    }

    public void OnClickRestartButton()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void OnClickNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}

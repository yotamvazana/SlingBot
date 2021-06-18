using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuGamePanel;

    [SerializeField] GameObject resetPanel;

    public void OnClickPauseButton()
    {
        Time.timeScale = 0;

        resetPanel.SetActive(true);

        pauseMenuGamePanel.SetActive(true);

    }

    public void OnClickResetPanel()
    {
        resetPanel.SetActive(false);

        pauseMenuGamePanel.SetActive(false);

        Time.timeScale = 1;
        
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

}

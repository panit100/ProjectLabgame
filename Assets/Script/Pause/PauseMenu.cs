using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
 
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1f){
            GameIsPaused = false;
            }
            
            if (GameIsPaused) 
            {
                Resume();
                Debug.Log("Resume");
            }else
            {
                Pause();
                Debug.Log("Pause");
            }
        }
    }
    public void Resume() 
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() 
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Setting() 
    {
        //add setting
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Shop"); //Add Menu Scenes
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

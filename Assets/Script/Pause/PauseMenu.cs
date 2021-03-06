﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject ShopUI;
    public GameObject OptionUI;
    public GameObject[] Button;
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(ShopUI.activeInHierarchy){
                ShopUI.SetActive(false);
                foreach(GameObject n in Button){
                    n.SetActive(true);
                }
                return;
            }
            if(OptionUI.activeInHierarchy){
                OptionUI.SetActive(false);
                PauseMenuUI.SetActive(true);
                return;
            }
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
        Cursor.visible = false;
        GameIsPaused = false;
    }

    void Pause() 
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        GameIsPaused = true;
    }

    public void LoadMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); //Add Menu Scenes
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}

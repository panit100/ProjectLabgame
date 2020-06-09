using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
    
}

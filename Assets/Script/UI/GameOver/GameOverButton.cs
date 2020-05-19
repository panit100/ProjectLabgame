using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Maimenu(){
        SceneManager.LoadScene(0);
    }
}

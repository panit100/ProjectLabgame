﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Restart(){
    SceneManager.LoadScene(1);
    }

    public void Maimenu(){
        SceneManager.LoadScene(0);
    }
}

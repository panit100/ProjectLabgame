﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void Stratgame(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public TextMeshProUGUI PreeKeyText;
    private void Start() {
        StartCoroutine(LoadAsynchronously(2));
    }

    IEnumerator LoadAsynchronously(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);

            if(operation.progress >= 0.9f){
                PreeKeyText.text = "Press any key to continue.";
                if(Input.anyKeyDown){
                    operation.allowSceneActivation = true;
                }
            }
            yield return null;
        }
        
    }


}

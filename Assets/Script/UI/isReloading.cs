using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class isReloading : MonoBehaviour
{
    TextMeshProUGUI ReloadingText;
    public float speed = 5f;
    

    // Start is called before the first frame update
    void Start()
    {
        ReloadingText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //FadeText();
    }    

    void FadeText(){
        ReloadingText.color = new Color(0,0,0,Mathf.Sin(Time.time * speed));

    }
}

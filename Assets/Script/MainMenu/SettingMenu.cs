using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider BGMslider;
    public Slider SFXslider;


    void Start()
    {
        BGMslider.value = GetBGM();     
        SFXslider.value = GetSFX();
    }

    public void settingBGM(float volume){
        audioMixer.SetFloat("BGM",volume);
    }

    public void settingSFX(float volume){
        audioMixer.SetFloat("SFX",volume);
    }

    public float GetBGM(){
         float value;
         bool result =  audioMixer.GetFloat("BGM", out value);
         if(result){
             return value;
         }else{
             return 0f;
         }
     }

    public float GetSFX(){
        float value;
        bool result =  audioMixer.GetFloat("SFX", out value);
        if(result){
           return value;
        }else{
           return 0f;
        }
    }
}

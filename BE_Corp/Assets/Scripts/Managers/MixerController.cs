using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer myAudioMixer;

    public void SetMasterVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Master_volume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("SFX_volume", Mathf.Log10(sliderValue) * 20);
    }    
    public void SetMusicVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Music_volume", Mathf.Log10(sliderValue) * 20);
    }    
    public void SetDialogVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("Dialog_volume", Mathf.Log10(sliderValue) * 20);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class SplCameraShake : MonoBehaviour
{
    public float shakeDuration = 0.3f;
    public float shakeAmplitude = 1.2f;
    public float shakeFrequency = 2.0f;

    private float shakeElapsedTime = 0f;


    public CinemachineVirtualCamera vCam;
    private CinemachineBasicMultiChannelPerlin vCamNoise;
    public string nomDeLaCam;

    public bool triggered = false; 

    // Start is called before the first frame update
    void Awake()
    {
        vCam = GameObject.Find(nomDeLaCam).GetComponent<CinemachineVirtualCamera>();
        if (vCam != null)
        {
            vCamNoise = vCam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        }

        if(triggered) Invoke("Shaker", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        //à remplacer par le trigger à l'avenir
        
        if(vCam != null || vCamNoise != null)
        {
            //si l'effet est en train d'être joué
            if(shakeElapsedTime > 0)
            {
                //paramètres noise de cinemachine
                vCamNoise.m_AmplitudeGain = shakeAmplitude;
                vCamNoise.m_FrequencyGain = shakeFrequency;

                //timer du shake
                shakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                //quand c'est fini on reset les variables
                triggered = false;
                vCamNoise.m_AmplitudeGain = 0f;
                shakeElapsedTime = 0f;
            }

        }
    }

    public void Shaker()
    {
        triggered = true;
        shakeElapsedTime = shakeDuration;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FirstDialogue : MonoBehaviour
{
    public BlockReference blockRef;
    public string playerPref;
    public float time;
    void Start()
    {
        if (PlayerPrefs.GetInt(playerPref) == 0)
        {
            Invoke("DialogDebut", time);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogDebut()
    {
        blockRef.Execute();
        PlayerPrefs.SetInt(playerPref, 1);
    }
}

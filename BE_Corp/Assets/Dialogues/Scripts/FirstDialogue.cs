using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FirstDialogue : MonoBehaviour
{
    public BlockReference blockRef;
    void Start()
    {
        Invoke("DialogDebut", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DialogDebut()
    {
        blockRef.Execute();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MisAJourEffect : Singleton<MisAJourEffect>
{
    public Image Fademaj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MiseAJour()
    {
        Fademaj.GetComponent<Animator>().SetTrigger("Maj");
    }
}

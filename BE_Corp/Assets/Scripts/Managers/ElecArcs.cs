using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ElecArcs : MonoBehaviour
{
    bool isActive;
    public GameObject[] arc;
    public GameObject orb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (orb.activeInHierarchy == true)
        {
            isActive = true;
        }
        else 
        isActive = false;

        if (isActive == true)
        {
            Sparkling();
        }
    }

    void Sparkling()
    {
        foreach (GameObject effet in arc)
        {
            effet.GetComponent<VisualEffect>().Play();
        } 

    }
}

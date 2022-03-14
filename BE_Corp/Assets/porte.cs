using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour
{
    public ScreenShake cameraShake;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
       
        StartCoroutine(cameraShake.Shaking());
        GameObject.Find("Panel").SetActive(true);

    }
    void OnMouseExit()
    {
        GameObject.Find("Panel").SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour
{
    public ScreenShake cameraShake;
    public GameObject Panel;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        Panel = GameObject.Find("Panel").gameObject;     
      
        Panel.SetActive(false);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {
       
     StartCoroutine(cameraShake.Shaking());
     Panel.SetActive(true);

    }
    void OnMouseExit()
    {

        
        Panel.SetActive(false);

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte : MonoBehaviour
{
    public SplCameraShake cameraShake;
    public GameObject Panel;
    
    

    // Start is called before the first frame update
    void Awake()
    {
        Panel = GameObject.Find("Panel").gameObject;
        cameraShake = this.gameObject.GetComponent<SplCameraShake>();
        Panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseOver()
    {

        cameraShake.Shaker();
        Panel.SetActive(true);

    }
    void OnMouseExit()
    {

        
        Panel.SetActive(false);

    }
}
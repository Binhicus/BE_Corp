using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomRadio : MonoBehaviour
{
    public bool Ok;
    public GameObject CamCuisine;
    public GameObject TexteMeteo;
    public AudioSource SonRadio;
    // Start is called before the first frame update
    void Start()
    {
        TexteMeteo=GameObject.FindWithTag("Finish");
        CamCuisine=GameObject.FindWithTag("CamCuisine");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&Ok)
        {
CamCuisine.GetComponent<Animator>().SetTrigger("Retour");
TexteMeteo.SetActive(false);
SonRadio.Stop();
Ok=false;
        }
    }

    private void OnMouseDown() {
        if(Ok==false)
        {
            CamCuisine.GetComponent<Animator>().SetTrigger("Radio");
            Ok=true;
            TexteMeteo.SetActive(true);
        }
    }
}

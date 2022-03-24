using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epouvan : MonoBehaviour
{
    public bool Dessus;
    private bool Une;
    public GameObject ButtonChange;
    public GameObject Epouvantail;
    public GameObject PorteManteau;

    public AudioSource Son;

    public PourPorte pourPorte;

    private ScreenShake camShake;
    private porte porte;
    // Start is called before the first frame update
    void Awake()
    {
        //camShake = GameObject.Find("Camera").GetComponent<ScreenShake>();
        porte = GameObject.Find("door").GetComponent<porte>();
        this.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&Dessus)
        {
            ButtonChange.SetActive(true);
        }
    }

    private void OnMouseEnter() {
        Dessus=true;
        Debug.Log("Mouse enter");
    }

    private void OnMouseExit() {
        Dessus=false;
        Debug.Log("Mouse enter");
    }

    public void Disparait()
    {
        if(Une==false)
        {
            ButtonChange.SetActive(false);
            Son.Play();
            Epouvantail.GetComponent<Animator>().SetTrigger("Go");
            PorteManteau.GetComponent<Animator>().SetTrigger("Go");
            //Destroy(camShake);
            Destroy(porte);
            Une=true;
            pourPorte.PeutOuvrir=true;
            PlayerPrefs.SetInt("Scarecrow", 1);
        }
        
    }
}

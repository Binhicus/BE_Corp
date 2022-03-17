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
    // Start is called before the first frame update
    void Start()
    {
        
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
        Une=true;
        pourPorte.PeutOuvrir=true;
        }
        
    }
}

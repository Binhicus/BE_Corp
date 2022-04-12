using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NombreInteraction : MonoBehaviour
{
    public int NbreInteractionTotale;
    public int NbreInteractionActuelle;
    public GameObject Papillon3;
    public GameObject Papillon2;
    public GameObject BleuEffet;
    public GameObject Papillon1;
    public AudioSource PerdInteraSon;
    private bool Une;
    public AudioSource FinFadeSon;

    public GameObject FadeFin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    /*if(NbreInteractionTotale==3){
        
        if(NbreInteractionActuelle==3)
        {
            Papillon1.SetActive(true);
            Papillon2.SetActive(true);
            Papillon3.SetActive(true);
        }

        if(NbreInteractionActuelle==2)
        {
            Papillon1.SetActive(true);
            Papillon2.SetActive(true);
            Papillon3.GetComponent<Animator>().SetTrigger("Perd");
                StartCoroutine(coroutineA());
        }

        if(NbreInteractionActuelle==1)
        {
            Papillon1.SetActive(true);
            Papillon2.SetActive(false);
            Papillon3.SetActive(false);
        }
        if(NbreInteractionActuelle==0)
        {
            Papillon1.SetActive(false);
            Papillon2.SetActive(false);
            Papillon3.SetActive(false);
        }
    }*/

    }

    public void PerdInteraction()
    {
        if(NbreInteractionActuelle>0&&!Une)
        {
            Une=true;
            NbreInteractionActuelle-=1;
            PerdInteraSon.Play();
            BleuEffet.GetComponent<Animator>().SetTrigger("Go");

        }    


        if(NbreInteractionActuelle==2)
        {
            Papillon3.GetComponent<Animator>().SetTrigger("Perd");
                StartCoroutine(coroutineA());
        }

        if(NbreInteractionActuelle==1)
        {
            Papillon2.GetComponent<Animator>().SetTrigger("Perd");
            StartCoroutine(coroutineB());
            
        }
        if(NbreInteractionActuelle==0)
        {
            Papillon2.GetComponent<Animator>().SetTrigger("Perd");  //Remettre Papillon 1 s'il y'a 3 interactions
            Debug.Log("FINI");
            FinInteraction();
        }
    }

    public void FinInteraction()
    {
        FinFadeSon.Play();
        FadeFin.SetActive(true);
        FadeFin.GetComponent<Animator>().SetTrigger("Go");
    }


    IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(2.0f);
        Une=false;
       Papillon3.SetActive(false);
    }

    IEnumerator coroutineB()
    {
        
        yield return new WaitForSeconds(2.0f);
        Une=false;
       Papillon2.SetActive(false);
    }

    IEnumerator coroutineC()
    {
        
        yield return new WaitForSeconds(2.0f);
        Une=false;
       Papillon1.SetActive(false);
    }
}

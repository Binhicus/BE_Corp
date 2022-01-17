using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolutionItem : MonoBehaviour
{
    public bool PressSpace;
    public List<GameObject> listObjetDiss = new List<GameObject>();
    public List<BoxCollider> listObjetDissCollider = new List<BoxCollider>();
    public List<Outline> listObjetDissOutline = new List<Outline>();
    public List<GameObject> listObjetDissE = new List<GameObject>();
    public List<BoxCollider> listPhysicDiss = new List<BoxCollider>();   // Pour que l'objet n'ai plus de physique
    public GameObject ParticleFour;      // Genre enlever des particules ou quoi

    public List<GameObject> listObjetApp = new List<GameObject>();
    public List<BoxCollider> listObjetAppCollider = new List<BoxCollider>();
    public List<Outline> listObjetAppOutline = new List<Outline>();
    public List<GameObject> listObjetAppE = new List<GameObject>();
    public List<BoxCollider> listPhysicApp = new List<BoxCollider>();       // Pour que l'objet n'ai plus de physique
    public List<GameObject> listObjetRemet = new List<GameObject>();        // Genre remttre des particules ou quoi

    public AudioSource Disso;
    public GameObject MettreAJourSouvenir;
    public GameObject BackSouvenir;
    public bool Dis;
    public float temps;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&!Dis&&PressSpace)
        {
            DisAp();
            
            StartCoroutine(coroutineA());
        }

        if(Input.GetKeyDown(KeyCode.Space)&&Dis&&PressSpace)
        {
            ApDis();
            
            StartCoroutine(coroutineB());
        }
    }

    /*public void Dissolution()
    {
        Disso.Play();
         for (int i = 0; i < listObjetDiss.Count; i++)
        {
            listObjetDiss[i].GetComponent<Animation>().SetTrigger("Disparait");

        }

            StartCoroutine(coroutineAttend());

        for (int i = 0; i < listObjetDiss.Count; i++)
        {
            listObjetDiss[i].SetActive(false);

        }

    }
    /*public void Apparait()
    {
        Disso.Play();
        for (int i = 0; i < listAnimApp.Count; i++)
        {
            listAnimApp[i].SetTrigger("Apparait");
        }
    }*/

    public void DisAp()
    {
        Disso.Play();
         for (int i = 0; i < listObjetDiss.Count; i++)
        {
            listObjetDiss[i].GetComponent<Animator>().SetTrigger("Disparait");
            listObjetDissCollider[i].enabled=false;
            listObjetDissOutline[i].enabled=false;
            listObjetDissE[i].SetActive(false);
            listPhysicDiss[i].enabled=false;
        }

        for (int j = 0; j < listObjetApp.Count; j++)
        {
            listObjetApp[j].GetComponent<Animator>().SetTrigger("Apparait");
            listObjetAppCollider[j].enabled=true;
            listPhysicApp[j].enabled=true;
        }

        StartCoroutine(coroutineEnleve());
    }

    public void ApDis()
    {
        Disso.Play();
        for (int j = 0; j < listObjetApp.Count; j++)
        {
            listObjetApp[j].GetComponent<Animator>().SetTrigger("Disparait");
            listObjetAppCollider[j].enabled=false;
            listObjetAppOutline[j].enabled=false;
            listObjetAppE[j].SetActive(false);
            listPhysicApp[j].enabled=false;
        }

        for (int i = 0; i < listObjetDiss.Count; i++)
        {
            listObjetDiss[i].GetComponent<Animator>().SetTrigger("Apparait");
            listObjetDissCollider[i].enabled=true;
            listPhysicDiss[i].enabled=true;
        }
    }

            public void ApparaitVoid()
        {
            Disso.Play();
            
            for (int m = 0; m < listObjetApp.Count; m++)
            {
            listObjetApp[m].GetComponent<Animator>().SetTrigger("Apparait");
            }

            for (int j = 0; j < listObjetAppCollider.Count; j++)
        {
            listObjetAppCollider[j].enabled=true;
        }


        for (int o = 0; o < listObjetAppOutline.Count; o++)
        {
            listObjetAppOutline[o].enabled=false;
        }

        for (int p = 0; p < listObjetAppE.Count; p++)
        {
            listObjetAppE[p].SetActive(false);
        }

            
        }
        /*MettreAJourSouvenir.SetActive(true);
        MettreAJourSouvenir.GetComponent<Animator>().SetTrigger("Choix");
        BackSouvenir.GetComponent<Animator>().SetTrigger("Retour");
        BackSouvenir.SetActive(false);*/

     IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(0.3f);
        Dis=true;
    }

    IEnumerator coroutineB()
    {
        
        yield return new WaitForSeconds(0.3f);
        Dis=false;
    }
    IEnumerator coroutineEnleve()
    {
        
        yield return new WaitForSeconds(1.5f);
         ParticleFour.SetActive(false);
        
    }
    IEnumerator coroutineRemet()
    {
        
        yield return new WaitForSeconds(1.5f);
        ParticleFour.SetActive(true);
    }
}

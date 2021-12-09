using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolutionItem : MonoBehaviour
{
    public List<GameObject> listObjetDiss = new List<GameObject>();
    public List<BoxCollider> listObjetDissCollider = new List<BoxCollider>();
    public List<Outline> listObjetDissOutline = new List<Outline>();
    public List<GameObject> listObjetDissE = new List<GameObject>();
    public List<BoxCollider> listPhysicDiss = new List<BoxCollider>();   // Pour que l'objet n'ai plus de physique

    public List<GameObject> listObjetApp = new List<GameObject>();
    public List<BoxCollider> listObjetAppCollider = new List<BoxCollider>();
    public List<Outline> listObjetAppOutline = new List<Outline>();
    public List<GameObject> listObjetAppE = new List<GameObject>();
    public List<BoxCollider> listPhysicApp = new List<BoxCollider>();       // Pour que l'objet n'ai plus de physique

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
        if(Input.GetKeyDown(KeyCode.Space)&&!Dis)
        {
            DisAp();
            
            StartCoroutine(coroutineA());
        }

        if(Input.GetKeyDown(KeyCode.Space)&&Dis)
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
        /*MettreAJourSouvenir.SetActive(true);
        MettreAJourSouvenir.GetComponent<Animator>().SetTrigger("Choix");
        BackSouvenir.GetComponent<Animator>().SetTrigger("Retour");
        BackSouvenir.SetActive(false);*/


    }

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
}

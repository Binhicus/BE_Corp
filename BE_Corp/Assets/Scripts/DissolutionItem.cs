using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolutionItem : MonoBehaviour
{
    public List<Animator> listAnimDiss = new List<Animator>();
    public List<Animator> listAnimApp = new List<Animator>();
    public AudioSource Disso;
    public GameObject MettreAJourSouvenir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dissolution()
    {
        Disso.Play();
         for (int i = 0; i < listAnimDiss.Count; i++)
        {
            listAnimDiss[i].SetTrigger("Disparait");
        }
    }
    public void Apparait()
    {
        Disso.Play();
        for (int i = 0; i < listAnimApp.Count; i++)
        {
            listAnimApp[i].SetTrigger("Apparait");
        }
    }

    public void DisAp()
    {
        Disso.Play();
         for (int i = 0; i < listAnimDiss.Count; i++)
        {
            listAnimDiss[i].SetTrigger("Disparait");
            Debug.Log("disparait allez");
        }

        for (int j = 0; j < listAnimApp.Count; j++)
        {
            listAnimApp[j].SetTrigger("Apparait");
        }

        

        //StartCoroutine(coroutineA());
    }

    /* IEnumerator coroutineA()
    {
        
        yield return new WaitForSeconds(1.0f);
        Disso.Play();
        for (int i = 0; i < listAnimApp.Count; i++)
        {
            listAnimApp[i].SetTrigger("Apparait");
        }
        MettreAJourSouvenir.SetActive(false);
    }*/
}

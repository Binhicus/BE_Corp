using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraTest : MonoBehaviour
{
    public GameObject OptionInteragis;
    public List<GameObject> OptionBase= new List<GameObject>();
    public bool DansChoixAvance;
    public AudioSource BoutonInterSon;
    public AudioSource Retour;
    public List<GameObject> OptionInterra= new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&DansChoixAvance)
        {
            for(int i = 0; i < OptionBase.Count; i++)
            {
            OptionBase[i].SetActive(true);
            }

            OptionInteragis.SetActive(false);
        }
    }

    public void Intera()
    {
        BoutonInterSon.Play();
        DansChoixAvance=true;
        for(int i = 0; i < OptionBase.Count; i++)
        {
            OptionBase[i].SetActive(false);
        }
        OptionInteragis.SetActive(true);
    }

    public void ChoixBase()
    {
        OptionInteragis.SetActive(false);
        for(int i = 0; i < OptionBase.Count; i++)
        {
            OptionBase[i].SetActive(true);
        }
    }

    public void PointerSurInteraFour()
    {
        for(int i = 0; i < OptionInterra.Count; i++)
            {
            OptionInterra[i].SetActive(true);
            OptionInterra[i].GetComponent<Animator>().SetTrigger("Apparait");
            }
    }

    public void PointerPasSurInteraFour()
    {
        for(int i = 0; i < OptionInterra.Count; i++)
            {
            OptionInterra[i].SetActive(false);
            OptionInterra[i].GetComponent<Animator>().SetTrigger("Disparait");
            }
    }
}

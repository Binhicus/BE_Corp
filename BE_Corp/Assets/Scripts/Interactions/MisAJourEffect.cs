using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class MisAJourEffect : Singleton<MisAJourEffect>
{
    public Image Fademaj;
    public BlockReference maj, tableau, mdp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MiseAJour()
    {
        Fademaj.GetComponent<Animator>().SetTrigger("Maj");
        maj.Execute();
    }

    public void TableauReveal()
    {
        Fademaj.GetComponent<Animator>().SetTrigger("Maj");
        tableau.Execute();
    }
    public void PasswordUpdate()
    {
        mdp.Execute();
    }

}

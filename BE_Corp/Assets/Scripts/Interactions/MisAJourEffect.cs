using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using TMPro;

public class MisAJourEffect : Singleton<MisAJourEffect>
{
    //public Image Fademaj;
    public AudioSource audioCue;
    public BlockReference maj, tableau, tableauUpdate, password;

    protected override void Awake()
    {
        base.Awake();
        //checkpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        //animator = checkpoint.GetComponent<Animator>();

    }
    void Update()
    {
        
    }

    public void MiseAJour()
    {
        //Fademaj.GetComponent<Animator>().SetTrigger("Maj");
        //loading.GetComponentInChildren<>
        audioCue.Play();
        //message.text = "Le souvenir a été mis à jour.";
        //animator.CrossFade("MemoryUpdated", 0.3f);
        maj.Execute();
    }

    public void TableauReveal()
    {
        //Fademaj.GetComponent<Animator>().SetTrigger("Maj");
        //tableau.Execute();
        audioCue.Play();
        //message.text = "Le tableau a été localisé.";
        tableau.Execute();
        //animator.CrossFade("TableauReveal", 0.3f);
    }
    
    public void TableauUpdated()
    {
        //Fademaj.GetComponent<Animator>().SetTrigger("Maj");
        //tableau.Execute();
        audioCue.Play();
        //message.text = "Une information visuelle a été ajouté au tableau.";
        tableauUpdate.Execute();
        //animator.CrossFade("TableauReveal", 0.3f);
    }
    public void PasswordUpdate()
    {
        //mdp.Execute();
        audioCue.Play();
        //message.text = "Un nouveau choix de mot de passe a été enregistré.";
        password.Execute();
    }

}

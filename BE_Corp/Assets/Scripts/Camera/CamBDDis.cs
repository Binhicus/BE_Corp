using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBDDis : MonoBehaviour
{
    public GameObject Book;
    public GameObject LivreFerme;
    public AudioSource SonFerme;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void OnEnable() {
        Book=GameObject.Find("BOOK");
        LivreFerme=GameObject.Find("BD_Tournesol_fermée");
        SonFerme=GameObject.Find("Ferme Livre").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable() {
        LivreFerme.SetActive(true);
        Book=GameObject.Find("BOOK");
        SonFerme.Play();
        Book.SetActive(false);
        PlayerPrefs.SetInt("LivreOpen",0);
    }
}

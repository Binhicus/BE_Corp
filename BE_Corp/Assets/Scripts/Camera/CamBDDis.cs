using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBDDis : MonoBehaviour
{
    public GameObject Book;
    public GameObject LivreFerme;

    // Start is called before the first frame update

    void Start()
    {
        
    }

    private void OnEnable() {
        Book=GameObject.Find("BOOK");
        LivreFerme=GameObject.Find("BD_Tournesol_fermée");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable() {
        LivreFerme.SetActive(true);
        Book=GameObject.Find("BOOK");
        Book.SetActive(false);
        PlayerPrefs.SetInt("LivreOpen",0);
    }
}

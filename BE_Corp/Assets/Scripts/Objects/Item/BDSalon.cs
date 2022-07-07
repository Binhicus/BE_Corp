using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class BDSalon :ClickableObject,IClicked, IAction
{

    public BlockReference question;

     public GameObject CameraActivate ;
     public GameObject AreaCam;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();

    public List<ActionWheelChoiceData> ListInteractPossible2 = new List<ActionWheelChoiceData>();
    public GameObject LivreOuvert,TSommaire;
    public AudioSource OuvreLivre;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Awake()
    {
        
        CameraActivate = GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraBD;
        //TSommaire = GameObject.FindGameObjectWithTag("Book");
        //TSommaire.SetActive(false);
    }

    // Update is called once per frame
    public void OnClickAction()
    {
        if(PlayerPrefs.GetInt("BDOk")==0)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
        }
        if(PlayerPrefs.GetInt("BDOk")==1)
        {
            CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible2 ;
        }
        
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);            
        
    }

    public void UtiliseLivre()
    {
        PlayerPrefs.SetInt("LivreOpen",1);
        this.GetComponent<BoxCollider>().enabled=false;
        CameraActivate.SetActive(true);

        GameObject[] IndiceZoneCollider ;
        IndiceZoneCollider = GameObject.FindGameObjectsWithTag("Indice Zone");


        AreaCam.SetActive(false);
        foreach (GameObject GameCol in IndiceZoneCollider)
        {
            GameCol.GetComponent<BoxCollider>().enabled = false ;
        }

        LivreOuvert.SetActive(true);
        TSommaire.SetActive(true);
        TSommaire.GetComponent<Animator>().SetBool("Go", true);
        OuvreLivre.Play();
        this.gameObject.SetActive(false);
        if(PlayerPrefs.GetInt("Cuisine Révélée")==1)
        {
            TSommaire.GetComponent<Animator>().SetTrigger("Apparait");
        }
    }


    public void OnOpen() { Debug.Log("Open"); }
    public void OnClose() { Debug.Log("Close"); }

    public void OnUse() { UtiliseLivre(); }
    public void OnInspect() {  }
    public void OnQuestion() { question.Execute(); }

    public void OnLunchActionAfterCloseDialogue() {}

    public void OnLook() {    Debug.Log("Observe"); }

    public void OnDrop() {}
    public void OnTake() {Debug.Log("Take") ;}

    public void OnPickUp()
    {
    }

    void Update()
    {
        if(PlayerPrefs.GetInt("LivreOpen")==0)
        {
            LivreOuvert.SetActive(false);
            this.GetComponent<BoxCollider>().enabled=true;
        }
    }
}


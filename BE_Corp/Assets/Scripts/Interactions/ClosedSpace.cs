using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ClosedSpace : ClickableObject, IHasItemInteraction, IClicked, IAction
{
    public string nomItem;
    public string inventoryItemID => nomItem;
    public AudioSource unlocked;
    public GameObject fog, emetteur, epee, bras, yeux, yeux2, bloqueur;
    public GameObject OuverturePorteChambre;

    public BlockReference question, inspect ;

    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>() ;
    public List<ActionWheelChoiceData> ListInteractPossible2 = new List<ActionWheelChoiceData>() ;


    private bool MouseOver = false ;
    private bool AsCameraShake = false ;
    public AudioSource CoupeEpee;


    private void Awake() 
    {

        if (PlayerPrefs.GetInt("Sequence 1 Done") == 0)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (PlayerPrefs.GetInt("Sequence 1 Done") == 1)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        fog = GameObject.Find("Gray Volume Fog");
        OuverturePorteChambre=GameObject.Find("Ouverture");

        if(PlayerPrefs.GetInt("Brume")==1)
        {
            this.GetComponent<BoxCollider>().enabled=false;
            fog.GetComponent<BoxCollider>().enabled = false;
        }
    }

  /*  void OnMouseOver()
    {
        MouseOver = true ;

        if(AsCameraShake && cameraShake.enabled == true)
        {
            if(cameraShake != null) cameraShake.Shaker();
            GlitchyBreak.Instance.GlitchEffectOn();
        }
    }

    void OnMouseExit()
    {
        MouseOver = false ;

        if(AsCameraShake)
        {
            GlitchyBreak.Instance.GlitchEffectOff();
        }
    }*/


    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            if(PlayerPrefs.GetInt("Scarecrow") == 0) CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible ;
            else CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible2 ;
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);          
        }

    }

    public void DoItemInteraction()
    {
        EffetEpee();
        EffetBrume();
        fog.GetComponent<BoxCollider>().enabled = false;
        bloqueur.SetActive(false);
        PlayerPrefs.SetInt("Brume", 1);
        OuverturePorteChambre.GetComponent<BoxCollider>().enabled=true;
        Jauge.Instance.stadeProg += 1;
        this.GetComponent<BoxCollider>().enabled=false;
    }

    public void ItemDropAnim() //////////////
    {

    }

    void EffetBrume()
    {
        emetteur.GetComponent<BrumeSpawn>().enabled = false;
        emetteur.GetComponent<Animator>().CrossFade("Fumée_End", 0.1f);
        
        yeux.GetComponent<Animator>().CrossFade("Yeux_fade", 0.1f);
        yeux2.GetComponent<Animator>().CrossFade("Yeux_fade", 0.1f);
        bras.GetComponent<Animator>().CrossFade("Bras_Fade", 0.1f);
        Invoke("DisableFace", 2f);
        //animation d'arr�t
    }
    void DisableFace()
    {
        emetteur.SetActive(false);
    }
    void EffetEpee()
    {
        epee.SetActive(true);
        CoupeEpee.Play();
        epee.GetComponent<Animator>().CrossFade("MvtEpée", 0.1f);
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        fog = GameObject.Find("Gray Volume Fog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  void Awake()
    {

    }*/

    public void OnOpen() {Debug.Log("Open") ;}
    public void OnClose() {Debug.Log("Close") ;}
    public void OnTake() {Debug.Log("Take") ;}
    public void OnUse() {Debug.Log("Use") ;}
    public void OnInspect() {inspect.Execute(); }
    public void OnQuestion() {question.Execute(); }
    public void OnLook() {}

    public void OnLunchActionAfterCloseDialogue() {}
}

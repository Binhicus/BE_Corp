using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouet : ClickableObject, IHasItemInteraction, IClicked, IAction
{
    List<GameObject> zonesZoom = new List<GameObject>(); //////////////////
    List<GameObject> steps = new List<GameObject>(); //////////////////
    public GameObject Tournevis; ///////////////////////
    public string nomItem = "Tournevis";
    public string inventoryItemID => nomItem;
    public GameObject piles;
    public BlockReference tip, finito, remarque;
    public List<ActionWheelChoiceData> ListInteractPossible1 = new List<ActionWheelChoiceData>();
    public List<ActionWheelChoiceData> ListInteractPossible2 = new List<ActionWheelChoiceData>() ;

    public void DoItemInteraction()
    {
        StartCoroutine(DelayBeforeDropAnim());
    }

    public void ItemDropAnim() //////////////
    {
        //CursorController.Instance.BoolFalseSetter();
        Instantiate(Tournevis, GameObject.Find("MC_Target").transform.position, Quaternion.identity);
        StartCoroutine(AnimDrop());
        //CursorController.Instance.BoolTrueSetter();
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(piles == null)    piles = GameObject.Find("Piles");
        if(PlayerPrefs.GetInt("Piles") == 1)
        {
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.enabled = false;
        }
    }

    void OnEnable()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            if(PlayerPrefs.GetInt("Piles") == 0)
            {
                CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible1 ;
            } else {
                CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible2 ;
            }
            
            CursorController.Instance.ActionWheelScript.TargetAction = this;
            CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);            
        }
    }

    public void OnOpen()
    {
        
    }

    public void OnClose()
    {
        
    }

    public void OnTake()
    {
        
    }

    public void OnUse()
    {
        
    }

    public void OnInspect()
    {
        if (PlayerPrefs.GetInt("Piles") < 1)
        {
            tip.Execute();
        }
        else finito.Execute();  
    }

    public void OnQuestion()
    {
        remarque.Execute();
    }

    public void OnLook()
    {
        
    }

    public void OnLunchActionAfterCloseDialogue()
    {
        
    }

    IEnumerator AnimDrop() /////////////////////
    {
        GameObject.Find("Tournevis Pivot instantiate(Clone)").transform.SetParent(Camera.main.transform);

        foreach (GameObject indiceZone in GameObject.FindGameObjectsWithTag("Indice Zone"))
        {
            zonesZoom.Add(indiceZone);
        }

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = false;
        }

        foreach (GameObject _steps in GameObject.FindGameObjectsWithTag("Steps"))
        {
            if (_steps.GetComponent<Collider>().enabled)
            {
                steps.Add(_steps);
            }
        }

        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].GetComponent<Collider>().enabled = false;
        }

        iTween.RotateTo(GameObject.Find("Tournevis Pivot instantiate(Clone)"), iTween.Hash("rotation", new Vector3(12.162f, -4.344f, -98.968f), "time", 0.5f, "delay", 0.25f));
        iTween.ScaleTo(GameObject.Find("Tournevis Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.1530433f, 0.2437882f, 0.1721426f), "time", 0.5f, "delay", 0.25f));
        yield return new WaitForSeconds(0.85f);
        GameObject.Find("Tournevis Pivot instantiate(Clone)").transform.SetParent(GameObject.Find("Voiture").transform);
        iTween.MoveTo(GameObject.Find("Tournevis Pivot instantiate(Clone)"), iTween.Hash("position", GameObject.Find("Tournevis Target").transform.position, "time", 0.75f, "easetype", iTween.EaseType.easeInOutSine, "delay", 1.5f));
        iTween.RotateTo(GameObject.Find("Tournevis Pivot instantiate(Clone)"), iTween.Hash("rotation", new Vector3(32.347f, 93.134f, -81.13f), "time", 0.75f, "delay", 1.5f));
        iTween.ScaleTo(GameObject.Find("Tournevis Pivot instantiate(Clone)"), iTween.Hash("scale", new Vector3(0.2246342f, 0.357828f, 0.2526677f), "time", 0.75f, "delay", 1.5f));
        Destroy(GameObject.Find("Tournevis Pivot instantiate(Clone)"), 3.5f);
        yield return new WaitForSeconds(3.5f);

        for (int i = 0; i < zonesZoom.Count; i++)
        {
            zonesZoom[i].GetComponent<Collider>().enabled = true;
        }

        for (int i = 0; i < steps.Count; i++)
        {
            steps[i].GetComponent<Collider>().enabled = true;
        }
    }

    IEnumerator DelayBeforeDropAnim()
    {
        yield return new WaitForSeconds(4f);
        piles.SetActive(true);
        PlayerPrefs.SetInt("Piles", 1);
    }
}

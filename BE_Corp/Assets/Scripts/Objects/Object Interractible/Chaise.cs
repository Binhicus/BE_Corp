using EPOOutline;
using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chaise : ClickableObject, IClicked, IAction
{
    public GameObject ballon, table;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();
    public BlockReference inspect, deny, admit;


    // Start is called before the first frame update
    private void Start()
    {
        VerifAnimation();
    }

    void VerifAnimation()
    {
        if (PlayerPrefs.GetInt("Chaise") == 0)
        {
            ballon.GetComponent<BallInteraction>().enabled = false;
            //ballon.GetComponent<Outlinable>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider>().enabled = false;
            this.gameObject.GetComponent<Animator>().SetTrigger("Chair Disable");
            this.gameObject.GetComponent<Outlinable>().enabled = false;
            this.enabled = false;
        }
    }

    public void Shrink()
    {
            //admit.Execute();
            GetComponent<BoxCollider>().enabled = false;
            //Son.Play();
            this.GetComponent<Animator>().SetTrigger("Chair Animation");
            PlayerPrefs.SetInt("Chaise", 1);
            ballon.GetComponent<BallInteraction>().enabled = true;
            table.GetComponent<BoxCollider>().enabled = false;
            //ballon.GetComponent<Outlinable>().enabled = true;
            this.gameObject.GetComponent<Outlinable>().enabled = false;
            this.enabled = false;
    }
        // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickAction()
    {
        if(GameObject.Find("BarbaraDialog") == null && GameObject.Find("AgentDialog") == false)
        {
            if(PlayerPrefs.GetInt("Chaise") == 0)
            {
                CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
                CursorController.Instance.ActionWheelScript.TargetAction = this;
                CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
            }
        }
    }
    public void OnClose(){    }

    public void OnInspect()
    { 
        //Debug.Log("Dialogue pour dire euuuuh c'est quoi ce binsss??");
        inspect.Execute();
        PlayerPrefs.SetInt("Inspect Chair", 1);
        table.GetComponent<BoxCollider>().enabled = true;
    }

    public void OnLook(){    }

    public void OnLunchActionAfterCloseDialogue(){    }

    public void OnOpen(){   }

    public void OnQuestion()
    {
        if (PlayerPrefs.GetInt("Avoue Table") == 1)
        {
            admit.Execute();
        }
        else deny.Execute();

    }

    public void OnTake(){    }

    public void OnUse(){    }
}

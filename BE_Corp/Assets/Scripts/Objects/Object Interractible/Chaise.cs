using EPOOutline;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chaise : ClickableObject, IClicked, IAction
{
    public GameObject ballon;
    public List<ActionWheelChoiceData> ListInteractPossible = new List<ActionWheelChoiceData>();


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
        //maj.Execute();
        GetComponent<BoxCollider>().enabled = false;
        //Son.Play();
        this.GetComponent<Animator>().SetTrigger("Chair Animation");
        PlayerPrefs.SetInt("Chaise", 1);
        ballon.GetComponent<BallInteraction>().enabled = true;
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
        CursorController.Instance.ActionWheelScript.ChoicesDisplay = ListInteractPossible;
        CursorController.Instance.ActionWheelScript.TargetAction = this;
        CursorController.Instance.ActionWheelScript.gameObject.SetActive(true);
    }
    public void OnClose(){    }

    public void OnInspect(){ Debug.Log("Dialogue pour dire euuuuh c'est quoi ce binsss??");  }

    public void OnLook(){    }

    public void OnLunchActionAfterCloseDialogue(){    }

    public void OnOpen(){   }

    public void OnQuestion(){ Shrink();  }

    public void OnTake(){    }

    public void OnUse(){    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControllerScript : MonoBehaviour
{
    [HideInInspector] public bool LunchActionAfterClose ;
    [HideInInspector] public IAction TargetAction ;

    private bool CanPressAgain = false ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCoroutine(WaitBeforeNextPress());
            PressNextText();
        }    
    }

    IEnumerator WaitBeforeNextPress()
    {
        CanPressAgain = true ;
        yield return new WaitForSeconds(1f);
        CanPressAgain = false ;
    }

    void PressNextText()
    {
        if(LunchActionAfterClose) TargetAction.OnLunchActionAfterCloseDialogue();

        gameObject.SetActive(false);
    }


}

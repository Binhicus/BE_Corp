using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

[System.Serializable]
public enum ActionOveringState
{
    NotOvering,
    Overing
}
public class ActionWheelChoice : MonoBehaviour
{
    public Image mainCircle;
    public Button mainButton;
    public Image colorCircle;
    public TextMeshProUGUI textObject;
    public Image iconObject;

    [HideInInspector] public ActionOveringState StateMouseOver = ActionOveringState.NotOvering ;

    void Update()
    {
     /*   if(StateMouseOver != ActionOveringState.NotOvering)
        {
            StateOvering();
        }*/
    }

    public void StateOvering(bool State)
    {
        if(State == false) 
        {
            StateMouseOver = ActionOveringState.NotOvering ;

        //    iconObject.GetComponent<RectTransform>().localScale = Vector3.one;
            colorCircle.GetComponent<Image>().raycastTarget = false ;
        }

        if(State == true)
        {
            StateMouseOver = ActionOveringState.Overing ;

          //  iconObject.GetComponent<RectTransform>().localScale = new Vector3(1.25f, 1.25f, 1.25f);
            colorCircle.GetComponent<Image>().raycastTarget = true ;
        } 

         
    }

    public void ClickButton()
    {
        Debug.Log("Hey : " + textObject.text );
    }
}

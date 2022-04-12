using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ActionWheelMouseManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ActionWheel ActionWheelParentScript ;

    private void Awake() {
        ActionWheelParentScript = transform.parent.GetComponent<ActionWheel>();
    }

 /*   void Update()
    {

            if(EventSystem.current.IsPointerOverGameObject() && ActionWheelChoiceParentScript.StateMouseOver == ActionOveringState.NotOvering)
            {
                ActionWheelChoiceParentScript.StateMouseOver = ActionOveringState.Overing ;
            } else {
                ActionWheelChoiceParentScript.StateMouseOver = ActionOveringState.NotOvering ;
            }          

    }*/

    public void OnPointerEnter(PointerEventData eventData)
    {
        //ActionWheelParentScript.Hover() ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //ActionWheelParentScript.EndHover();
    }
}

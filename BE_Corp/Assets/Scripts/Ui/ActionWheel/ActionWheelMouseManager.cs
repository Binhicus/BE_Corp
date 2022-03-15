using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class ActionWheelMouseManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ActionWheelChoice ActionWheelChoiceParentScript ;

    private void Awake() {
        ActionWheelChoiceParentScript = transform.parent.transform.parent.GetComponent<ActionWheelChoice>();
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
        ActionWheelChoiceParentScript.StateMouseOver = ActionOveringState.Overing ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ActionWheelChoiceParentScript.StateMouseOver = ActionOveringState.NotOvering ;
    }
}

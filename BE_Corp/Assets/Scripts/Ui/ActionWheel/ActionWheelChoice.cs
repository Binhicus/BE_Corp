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
        if(StateMouseOver != ActionOveringState.NotOvering)
        {
            StateOvering();
        }
    }

    public void StateOvering()
    {
        Debug.Log("Over : " + textObject.text + "   /   " + StateMouseOver); 
    }
}

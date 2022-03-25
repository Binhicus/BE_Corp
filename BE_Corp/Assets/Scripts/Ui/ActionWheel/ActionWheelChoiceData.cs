using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ActionWheel - Action")]
public class ActionWheelChoiceData : ScriptableObject
{
    [HideInInspector] public string NameAction;
    public string NameActionFR;
    public string NameActionEN;

    public Sprite IconAction;
    public GameObject action;


    private void Update() 
    {
        if(PlayerPrefs.GetInt("Langue") == 0) NameAction = NameActionFR ;
        if(PlayerPrefs.GetInt("Langue") == 1) NameAction = NameActionEN ;

    }
}

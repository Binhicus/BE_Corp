using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    void OnOpen() ;
    void OnClose() ;
    void OnTake() ;    
    void OnUse() ;    
    void OnInspect() ; 
    void OnQuestion() ;


    void OnLunchActionAfterCloseDialogue();
}

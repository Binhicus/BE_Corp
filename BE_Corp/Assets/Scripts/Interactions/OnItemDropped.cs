using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FeedbackType
{
    KeyOpener,
    Autre
}
public class OnItemDropped : MonoBehaviour
{
    // Que se passe-t-il quand on drop l'objet sur un trigger
    public FeedbackType feedbackType; 
    [SerializeField]
    string triggerObject;

    public string inventoryItemID => throw new System.NotImplementedException();

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == triggerObject && feedbackType == FeedbackType.KeyOpener)
        {
            Debug.Log("Hop c'est dans le tiekson");
        }
    }

/*public void DoItemInteraction()
    {
        Debug.Log("C'est ouvert");
    }*/
}

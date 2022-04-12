using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHasItemInteraction
{ //à mettre sur objet recevant l'item pour l'interaction
    string inventoryItemID { get; }
    void DoItemInteraction();
}

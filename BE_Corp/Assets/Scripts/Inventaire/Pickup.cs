using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Inventory inventory;
    public Sprite itemButton;
    public GameObject ButtonChoix;
    public NombreInteraction nombreInteraction;
    public bool ObjetRecupere;
    public bool DebloqueNouveauxChoix;
    public List<GameObject> nouveauxChoix = new List<GameObject>();
    public int NumeroStockageSlot;

    public void Ramasse()
    {
        Debug.Log("Appuie");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
                if(inventory.isFull[i] == false)
                {
                    // L'item peut être ajouté
                    inventory.isFull[i] = true;
                    inventory.slots[i].GetComponent<Image>().sprite=itemButton;
                    Instantiate(itemButton, inventory.slots[i].transform);
                    NumeroStockageSlot=i;
                    ButtonChoix.SetActive(false);
                    Debug.Log("Ajout");
                   // nombreInteraction.PerdInteraction();
                    ObjetRecupere=true;

                    if(DebloqueNouveauxChoix)
                    {
                        for (int j = 0; j < nouveauxChoix.Count; j++)
                        {
                            nouveauxChoix[j].SetActive(true);
                        }
                    }
                    break;
                }
        }
    }
    
}

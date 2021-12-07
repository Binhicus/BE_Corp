using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public Inventory inventory;
    public Sprite itemButton;
    public GameObject ButtonChoix;
    public bool EnleveItem;
    public GameObject EnleveItemScene;
    public NombreInteraction nombreInteraction;
    public List<GameObject> ChoixSupprime = new List<GameObject>();
    public bool ObjetRecupere;
    public bool DebloqueNouveauxChoix;
    public List<GameObject> nouveauxChoix = new List<GameObject>();
    public int NumeroStockageSlot;

    public bool PerdInteractionOuPas;

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

                    if(PerdInteractionOuPas)
                    {
                        nombreInteraction.PerdInteraction();
                    }
                  
                    ObjetRecupere=true;

                    if(EnleveItem)
                    {
                        EnleveItemScene.SetActive(false);
                    }
                    if(DebloqueNouveauxChoix)
                    {
                        for (int j = 0; j < nouveauxChoix.Count; j++)
                        {
                            nouveauxChoix[j].SetActive(true);
                        }
                    }


                    for (int k = 0; k < ChoixSupprime.Count; k++)
                        {
                            ChoixSupprime[k].SetActive(false);
                        }


                    break;
                }
        }
    }
    
}

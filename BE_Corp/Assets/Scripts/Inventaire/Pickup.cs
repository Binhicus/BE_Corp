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
    public bool AjouteItem;
    public AudioSource AjouteItemSon;
    public List<GameObject> AjouteDesItems = new List<GameObject>();
    public NombreInteraction nombreInteraction;
    public List<GameObject> ChoixSupprime = new List<GameObject>();
    public bool ObjetRecupere;
    public bool DebloqueNouveauxChoix;
    public List<GameObject> nouveauxChoix = new List<GameObject>();
    public int NumeroStockageSlot;
    public AudioSource PrendOBJ;
    public bool InteragitAvecObjet;

    public TriggerObject triggerObject; // le triggerobject de l'objet sur lequel on intéragit

    public bool PerdInteractionOuPas;

    public void Interact()
    {
        Debug.Log("Appuie");
        for (int i = 0; i < inventory.slots.Length; i++)
        {
                    InteragitAvecObjet=true;
                    PrendOBJ.Play();
                    ButtonChoix.SetActive(false);
                    triggerObject.dedans=false;
                    triggerObject.ChoixRestant-=1;
                    Debug.Log("Ajout");

                    if(PerdInteractionOuPas)
                    {
                        nombreInteraction.PerdInteraction();        // Si on enlève une interaction parmi celles qu'on a
                    }
                  
                    ObjetRecupere=true;

                    if(EnleveItem)                                  // Si on fait disparaitre un objet ( exemple on ramasse un verre donc) le verre disparait de la scène)
                    {
                        EnleveItemScene.SetActive(false);
                    }
                    if(DebloqueNouveauxChoix)                       // Est ce qu'on débloque de nouveaux choix après cette action ? ( On ramasse un verre vide donc au robinet on gagnera l'option : "remplir le verre")
                    {
                        for (int j = 0; j < nouveauxChoix.Count; j++)
                        {
                            nouveauxChoix[j].SetActive(true);
                        }
                    }

                    if(AjouteItem)                              // Est ce qu'un item s'ajoute dans la scène ? Exemple un emplacement , une particule de feu , etc..
                    {
                        for (int k = 0; k < AjouteDesItems.Count; k++)
                        {
                            AjouteDesItems[k].SetActive(true);
                        }
                    }


                    for (int k = 0; k < ChoixSupprime.Count; k++)   // Est ce que notre action enlève des choix d'un autre objet ? Exemple si on ramasse du chocolat et qu'on le jette à la poubelle et qu'on va dans la cuisine , l'option "faire un gateau au chocolat" aura disparu
                        {
                            ChoixSupprime[k].SetActive(false);
                        }

                    if(DebloqueNouveauxChoix)
                    {
                        AjouteItemSon.Play();
                    }
        }
    }



    public void Ramasse()
    {
        Debug.Log("Appuie");
        for (int i = 0; i < inventory.slots.Length; i++)            // Quand on ramasse un objet à mettre dans l'inventaire
        {
                if(inventory.isFull[i] == false)
                {
                    // L'item peut être ajouté
                    InteragitAvecObjet=true;
                    inventory.isFull[i] = true;
                    inventory.slots[i].GetComponent<Image>().sprite=itemButton;
                    Instantiate(itemButton, inventory.slots[i].transform);
                    NumeroStockageSlot=i;
                    PrendOBJ.Play();
                    triggerObject.dedans=false;
                    ButtonChoix.SetActive(false);
                    triggerObject.ChoixRestant-=1;
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

                    if(AjouteItem)
                    {
                        for (int k = 0; k < AjouteDesItems.Count; k++)
                        {
                            AjouteDesItems[k].SetActive(true);
                        }
                    }


                    for (int k = 0; k < ChoixSupprime.Count; k++)
                        {
                            ChoixSupprime[k].SetActive(false);
                        }

                    if(DebloqueNouveauxChoix)
                    {
                        AjouteItemSon.Play();
                    }

                    break;
                }
        }
    }
    
}

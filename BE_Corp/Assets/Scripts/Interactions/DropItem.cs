using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropItem : MonoBehaviour
{
    public Pickup pickup;
    public List<GameObject> BoutonChoix;
    public bool DebloqueNouveauxChoix;
    public Sprite None;
    public List<GameObject> nouveauxChoix = new List<GameObject>();
    public bool PerdInteraction;
    public NombreInteraction nombreInteraction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Drop()
    {
        pickup.inventory.isFull[pickup.NumeroStockageSlot]=false;
        pickup.inventory.slots[pickup.NumeroStockageSlot].GetComponent<Image>().sprite=None;  // On remplace le sprite de l'objet qu'on dépose par rien
        for (int i = 0; i < BoutonChoix.Count; i++)
        {
            BoutonChoix[i].SetActive(false);
        }

        if(PerdInteraction)
        {
            nombreInteraction.PerdInteraction();
        }
        
    }
}

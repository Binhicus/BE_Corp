using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jouet : ClickableObject, IHasItemInteraction
{
    public string nomItem = "Tournevis";
    public string inventoryItemID => nomItem;
    public GameObject piles;

    public void DoItemInteraction()
    {
        piles.SetActive(true);
    }

    // Start is called before the first frame update
    void Awake()
    {
        piles = GameObject.Find("Piles");
    }

    void OnEnable()
    {
        if (piles.activeInHierarchy)
        {
            piles.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

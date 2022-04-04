using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnInventory : MonoBehaviour
{
    public GameObject Inventory;
    public bool Appuie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void Dessus()
    {
        Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(-79, 0,0);
    }
    public void PasDessus()
    {
       Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, 0,0);
    }


    }

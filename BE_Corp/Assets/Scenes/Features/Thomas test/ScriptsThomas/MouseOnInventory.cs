using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnInventory : MonoBehaviour
{
    public GameObject Inventory;
    public bool Vasy;
    // Start is called before the first frame update
    void Start()
    {
        Vasy=true;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void Dessus()
    {
        if(!GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraOrdi.activeSelf) 
        {
            Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(-79, 0,0);            
        }

    }
    public void PasDessus()
    {
        if(Vasy==true)
        {
            Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, 0,0);
        }
       
    }


    }

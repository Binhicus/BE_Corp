using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOnInventory : MonoBehaviour
{
    public GameObject Inventory;
    public bool isOn;
    public Animator animHUD;
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
        if (!isOn)
        {
            
            if(!GameObject.Find("---- CAMERAS ----").GetComponent<CameraContainerScript>().CameraOrdi.activeSelf) 
            {
                isOn = true;
                //Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(-79, 0,0);            
                animHUD.CrossFade("Window In", 0.1f);               
            }
        }
    }
    public void PasDessus()
    {
        if(isOn==true)
        {   
            isOn = false;
            //Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, 0,0);
            Debug.Log("allez là");
            animHUD.CrossFade("Window Out", 0.1f);           
        }
    }

    public void MontreObjetRecup()
    {
         StartCoroutine(coroutineA());
    }

    IEnumerator coroutineA()
    {
        //Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(10, 0,0);  
        animHUD.CrossFade("Window In", 0.1f);
        yield return new WaitForSeconds(2.5f);
        animHUD.CrossFade("Window Out", 0.1f);
        //Inventory.GetComponent<RectTransform>().anchoredPosition = new Vector3(150, 0,0);

    }
}

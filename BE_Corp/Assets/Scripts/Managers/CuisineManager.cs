using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuisineManager : MonoBehaviour
{
    public GameObject radio, gateau, microOndes, cuisineAvant, cuisineApres;
    // Start is called before the first frame update
   void OnEnable()
   {
        CuisineLoader();   
   }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CuisineState()
    {
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 0)
        {
            cuisineAvant.SetActive(true);
            cuisineApres.SetActive(false);
        }
        if (PlayerPrefs.GetInt("Cuisine Révélée") == 1)
        {
            cuisineAvant.SetActive(true);
            cuisineApres.SetActive(false);
        }
    }
     public void CleObtenue()
     {
        PlayerPrefs.SetInt("Key", 1 );
     }

    public void CuisineLoader()
    {
        CuisineState();
    }
}

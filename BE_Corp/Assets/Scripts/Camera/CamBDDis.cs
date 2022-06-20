using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamBDDis : MonoBehaviour
{
    public GameObject Book;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable() {
        Book.SetActive(false);
        PlayerPrefs.SetInt("LivreOpen",0);
    }
}

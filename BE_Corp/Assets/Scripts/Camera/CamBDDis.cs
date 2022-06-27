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

    private void OnEnable() {
        Book=GameObject.Find("BOOK");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable() {
        Book=GameObject.Find("BOOK");
        Book.SetActive(false);
        PlayerPrefs.SetInt("LivreOpen",0);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IClicked, IItemInventaire 
{
    public string nomDeLaClef;
    private GameObject key;

    public string Name => "Clef";
    public Sprite _Image;
    public Sprite Image => _Image;

    //public string matricule;
    //public string itemID => matricule;

    private void OnEnable()
    {
        key = GameObject.Find(nomDeLaClef);
    }
    public void OnClickAction()
    {
       // Destroy(key);  // Doit-il se passer qqch de particulier quand on clique sur cette objet?
    }

    //les 2 fonctions suivantes sont à reprendre pour chaque objet nécessitant d'être dans l'inventaire
    public void OnPickUp()
    {
        gameObject.SetActive(false); // Se qu'il se passe si l'objet est ramassable
    }

    public void OnDrop()
    {
        Debug.Log(this);
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }
}

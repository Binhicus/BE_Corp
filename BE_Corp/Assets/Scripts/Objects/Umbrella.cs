using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Umbrella : MonoBehaviour, IClicked, IItemInventaire
{
    public string nomDuParapluie;
    private GameObject parapluie;
    public string Name => "Umbrella";

    public Sprite _Image;
    public Sprite Image => _Image;

    public void OnClickAction()
    {
        // pour l'instant rien de spécial
    }

    public void OnDrop()
    {
        Debug.Log(this);
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    public void OnPickUp()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        parapluie = GameObject.Find(nomDuParapluie);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolutionItem : MonoBehaviour
{
    public List<Animator> listAnim = new List<Animator>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dissolution()
    {
         for (int i = 0; i < listAnim.Count; i++)
        {
            listAnim[i].SetTrigger("Disparait");
        }
    }
    public void Apparait()
    {
        for (int i = 0; i < listAnim.Count; i++)
        {
            listAnim[i].SetTrigger("Apparait");
        }
    }
}

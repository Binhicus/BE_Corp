using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jauge : MonoBehaviour
{
    public GameObject[] orbes;
    public int stadeProg = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Illuminate()
    {
        for (int i = 0; i < orbes.Length; i++)
        {
            if(i <= stadeProg - 1)
            {
                orbes[i].SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Illuminate();
    }
}

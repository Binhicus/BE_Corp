using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.VFX;

//[ExecuteInEditMode()]
public class Jauge : Singleton<Jauge>
{
    
    public GameObject[] orbes;
    public int stadeProg = 0;
    /*
    public int maximum,minimum;
    public int current;
    public Image mask, fill;
    public Color color;
    */
    protected override void Awake()
    {
        base.Awake();
    }
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
                //orbes[i].GetComponent<VisualEffect>().Play();         
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Illuminate();
    }

    /*
    void GetCurrentFill()
    {
        float currentOffset = current - minimum;
        float maximumOffset = maximum - minimum;
        float fillAmount = currentOffset / maximumOffset;
        mask.fillAmount = fillAmount;

        fill.color = color;
    }*/
}

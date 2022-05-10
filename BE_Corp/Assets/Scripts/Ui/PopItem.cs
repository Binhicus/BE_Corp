using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopItem : MonoBehaviour
{
    private bool UneFois;
    public MouseOnInventory mouseOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<Image>().sprite!=null&&!UneFois)
        {
            UneFois=true;
            AnimItem();
        }
        if(this.GetComponent<Image>().sprite==null)
        {
            UneFois=false;
            this.GetComponent<Animator>().SetTrigger("Reset");

        }


    }

    public void AnimItem()
    {
        StartCoroutine(coroutineA());
    }

    IEnumerator coroutineA()
    {
        this.GetComponent<Animator>().ResetTrigger("Reset");
        this.GetComponent<Animator>().SetTrigger("Pop");
        mouseOn.MontreObjetRecup();
        yield return new WaitForSeconds(2.0f);
        this.GetComponent<Animator>().ResetTrigger("Pop");

       
    }
}

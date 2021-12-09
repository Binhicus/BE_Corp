using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public AudioSource SonNext;
    public DissolutionItem dissolutionItem;
    public bool PeutCliquer;

    public int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
        coroutineWait();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&PeutCliquer)
        {
            if (textComponent.text == lines[index])
            {
                PeutCliquer=false;
                SonNext.Play();
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if(PeutCliquer==false)
        {
            StartCoroutine(coroutineWait());
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if(index < lines.Length -1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
             dissolutionItem.DisAp();
             PeutCliquer=false;
            StopAllCoroutines();
             this.gameObject.SetActive(false);
        }
    }


    IEnumerator coroutineWait()
    {
        
        yield return new WaitForSeconds(1.0f);
        PeutCliquer=true;
       
    }
}
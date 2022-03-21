using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourPorte : MonoBehaviour
{
    public bool Dessus;
    public bool PeutOuvrir;

    public GameObject TextePo;
    private bool Peut;
    private bool Un;
    public GameObject Pas;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&Dessus&&!PeutOuvrir&&!Peut)
        {
            Peut=true;
            StartCoroutine(coroutineA());
        }

        if (Input.GetMouseButtonDown(0)&&Dessus&&PeutOuvrir&&!Un)
        {
            Un=true;
            this.GetComponent<Animator>().SetTrigger("Go");
            gameManager.EpouvantailOk();
            Pas.SetActive(true);
        }
    }

     private void OnMouseEnter() {
        Dessus=true;
        Debug.Log("Mouse enter");
    }

    private void OnMouseExit() {
        Dessus=false;
        Debug.Log("Mouse enter");
    }


    IEnumerator coroutineA()
    {
        TextePo.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        TextePo.SetActive(false);
        Peut=false;
       
    }
}

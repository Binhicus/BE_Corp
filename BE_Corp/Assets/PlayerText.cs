using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerText : MonoBehaviour
{
    public GameObject playertext;

    // Start is called before the first frame update
    void Start()
    {
        playertext.SetActive(false);
    }

    public void OnMouseOver()
    {
        playertext.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

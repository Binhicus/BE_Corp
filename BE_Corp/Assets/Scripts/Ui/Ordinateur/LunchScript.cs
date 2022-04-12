using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LunchScript : MonoBehaviour
{
    [SerializeField] private RectTransform LoadingImg ;
    public float AnimationSpeed = 0.05f ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingAnimation());
    }

    IEnumerator LoadingAnimation()
    {
        yield return new WaitForSeconds(AnimationSpeed) ;
        LoadingImg.Rotate(new Vector3(0,0,-36f)) ;
        StartCoroutine(LoadingAnimation());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

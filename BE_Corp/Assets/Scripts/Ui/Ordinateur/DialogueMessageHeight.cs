using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class DialogueMessageHeight : MonoBehaviour
{
    [SerializeField] private RectTransform ThisRectTransf ;
    [SerializeField] private RectTransform BackgroundRectTransf ;
    [SerializeField] private TextMeshProUGUI TMPText ;

    void Start()
    {
        StartCoroutine(SetHeight());
    }

    IEnumerator SetHeight()
    {
        yield return new WaitForSeconds(0.00001f);

        Vector2 NewSize ;

        if(TMPText.preferredWidth < 795f)
        {
            NewSize.x = TMPText.preferredWidth ;
        } else {
            NewSize.x =  800f ;
        }

        ThisRectTransf.sizeDelta = new Vector2(NewSize.x, 0f) ;
        BackgroundRectTransf.sizeDelta = new Vector2(NewSize.x, 0f) ;     

        NewSize.y = TMPText.preferredHeight ;

        ThisRectTransf.sizeDelta = new Vector2(NewSize.x, NewSize.y + 25f) ;
        BackgroundRectTransf.sizeDelta = new Vector2(NewSize.x, NewSize.y + 25f) ;      

        transform.parent.GetComponent<VerticalLayoutGroup>().spacing = transform.parent.GetComponent<VerticalLayoutGroup>().spacing - 1f ;
        transform.parent.GetComponent<VerticalLayoutGroup>().spacing = transform.parent.GetComponent<VerticalLayoutGroup>().spacing + 1f ;

        yield return new WaitForSeconds(0.00001f);
        if(GameObject.Find("Message") != null) GameObject.Find("Message").GetComponent<MessageManager>().HeightDialogueDisplay();
        yield return new WaitForSeconds(0.00001f);
        if(GameObject.Find("Message") != null) GameObject.Find("Message").GetComponent<MessageManager>().SetHeightNormally();
    }


}

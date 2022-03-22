using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

[System.Serializable]
public class ActionWheelActionData
{
    public string NameAction;
    public Sprite IconAction;
    public GameObject action;
}

public class ActionWheel : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
    //public List<ActionWheelActionData> choices = new List<ActionWheelActionData>();
    public List<ActionWheelChoiceData> ChoicesDisplay = new List<ActionWheelChoiceData>();
    public Transform ActionChoiceContainer ;
    public TextMeshProUGUI TitleCurrentActionChoice ;
    public GameObject choicePrefab;
    List<ActionWheelChoice> choiceObjects = new List<ActionWheelChoice>();

    public List<Color> colors = new List<Color>();

    private bool MouseHover = false ;

    void Start() 
    {
        SetActionWheel();
    }

    public void SetWheel()
    { SetActionWheel(); }

    private void OnEnable() {
        SetActionWheel();
    }

    public void SetActionWheel()
    {
        for (int i = 0; i < ActionChoiceContainer.transform.childCount; i++)
        {
            Destroy(ActionChoiceContainer.transform.GetChild(i).gameObject);
        }



        for (int i = 0; i < ChoicesDisplay.Count; i++)
        {
            ActionWheelChoice choiceObject = Instantiate(choicePrefab, ActionChoiceContainer.transform).GetComponent<ActionWheelChoice>();
            choiceObjects.Add(choiceObject);
            Vector3 rotation = choiceObject.transform.localRotation.eulerAngles;

            float angle = 360f / ChoicesDisplay.Count ;    
            choiceObject.MainCircle.fillAmount = angle / 360f;     
            rotation.z = angle * i ; 
            float radianAngle = rotation.z * Mathf.Deg2Rad - (angle * Mathf.Deg2Rad * 0.5f);    

            choiceObject.transform.localRotation = Quaternion.Euler(rotation);

            choiceObject.IconObject.sprite = ChoicesDisplay[i].IconAction;
            choiceObject.IconObject.transform.rotation = Quaternion.identity;

            SetAngledPosition(choiceObject.IconObject.transform, ActionChoiceContainer.transform.position, radianAngle, 67.5f);
        }
    }
    

    void SetAngledPosition(Transform obj, Vector3 center, float angle, float radius)
    {
        Vector3 position = obj.position;
        position.x = center.x + Mathf.Cos(angle) * radius;
        position.y = center.y + Mathf.Sin(angle) * radius;
        obj.position = position;
    }



    private void Update() 
    {
        for (int CAW = 0; CAW < ActionChoiceContainer.transform.childCount; CAW++)
        {
            ActionChoiceContainer.transform.GetChild(CAW).GetComponent<ActionWheelChoice>().StateOvering(false);
        }

        if(GetAngleMouseOvered() >= 0 && GetAngleMouseOvered() < ActionChoiceContainer.transform.childCount)
        {
            ActionChoiceContainer.transform.GetChild(GetAngleMouseOvered()).GetComponent<ActionWheelChoice>().StateOvering(true);
            TitleCurrentActionChoice.text = ChoicesDisplay[GetAngleMouseOvered()].NameActionFR ;
        }
    }



    private Vector2 NormalizedMousePosition ;
    private float CurrentAngle ;
    private int Selection ;

    int GetAngleMouseOvered()
    {
        NormalizedMousePosition = new Vector2((Input.mousePosition.x - (Screen.width/ 2 + GetComponent<RectTransform>().anchoredPosition.x *1.375f)) , (Input.mousePosition.y - (Screen.height/ 2 + GetComponent<RectTransform>().anchoredPosition.y*1.375f)));
        CurrentAngle = Mathf.Atan2(NormalizedMousePosition.y, NormalizedMousePosition.x) * Mathf.Rad2Deg ;

        CurrentAngle = (CurrentAngle + 360f + (360 / ChoicesDisplay.Count)) % 360f ;

        Selection = (int) CurrentAngle / (360 / ChoicesDisplay.Count) ;


        return Selection ;
    }

    public void CloseWheel()
    {
        gameObject.SetActive(false);
    }

}

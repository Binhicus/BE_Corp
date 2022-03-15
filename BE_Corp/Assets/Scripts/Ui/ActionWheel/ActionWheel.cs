using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionWheelActionData
{
    public string NameAction;
    public Sprite IconAction;
    public GameObject action;
}

public class ActionWheel : MonoBehaviour
{
    //public List<ActionWheelActionData> choices = new List<ActionWheelActionData>();
    public List<ActionWheelChoiceData> ChoicesDisplay = new List<ActionWheelChoiceData>();
    public GameObject choicePrefab;
    List<ActionWheelChoice> choiceObjects = new List<ActionWheelChoice>();

    public List<Color> colors = new List<Color>();


    void Start() 
    {
        SetActionWheel();
    }
    public void SetWheel()
    {SetActionWheel();}

    public void SetActionWheel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }



        for (int i = 0; i < ChoicesDisplay.Count; i++)
        {
            ActionWheelChoice choiceObject = Instantiate(choicePrefab, transform).GetComponent<ActionWheelChoice>();
            choiceObjects.Add(choiceObject);
            Vector3 rotation = choiceObject.transform.localRotation.eulerAngles;

            float angle = 0 ;
            float radianAngle = 0 ;
            if(i == 0) 
            {
                angle = 360f - (45f * (ChoicesDisplay.Count - 1)) ;

                choiceObject.mainCircle.fillAmount = angle / 360f;         

                rotation.z = 90f - (22.5f * (ChoicesDisplay.Count - 1)); 
                radianAngle = -1.5f;    
            } else {
                angle = 45f ; 
                choiceObject.mainCircle.fillAmount = angle / 360f ;  

                float Angle0 = 90f - (22.5f * (ChoicesDisplay.Count - 1));

                rotation.z = angle * i + Angle0 ; 
                  
                radianAngle = rotation.z * Mathf.Deg2Rad - (angle * Mathf.Deg2Rad * 0.5f);                     
            }
            

            choiceObject.transform.localRotation = Quaternion.Euler(rotation);

            choiceObject.colorCircle.color = colors[i];

            choiceObject.textObject.text = ChoicesDisplay[i].NameActionFR;
            choiceObject.iconObject.sprite = ChoicesDisplay[i].IconAction;
        //    choiceObject.mainButton.onClick.AddListener(() => Debug.Log("Hey"));
            choiceObject.textObject.transform.rotation = Quaternion.identity;
            choiceObject.iconObject.transform.rotation = Quaternion.identity;
      
            SetAngledPosition(choiceObject.textObject.transform, transform.position, radianAngle, 150f);
            SetAngledPosition(choiceObject.iconObject.transform, transform.position, radianAngle, 90f);
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
        for (int CAW = 0; CAW < transform.childCount; CAW++)
        {
            transform.GetChild(CAW).GetComponent<ActionWheelChoice>().StateOvering(false);
        }

        if(GetAngleMouseOvered() == 0 || (GetAngleMouseOvered() >= transform.childCount && GetAngleMouseOvered() <= 7))
        {
            transform.GetChild(0).GetComponent<ActionWheelChoice>().StateOvering(true);
        } else {
            transform.GetChild(GetAngleMouseOvered()).GetComponent<ActionWheelChoice>().StateOvering(true);            
        }   
    }



    private Vector2 NormalizedMousePosition ;
    private float CurrentAngle ;
    private int Selection ;

    int GetAngleMouseOvered()
    {
        NormalizedMousePosition = new Vector2(Input.mousePosition.x - Screen.width/2, Input.mousePosition.y - Screen.height/2);
        CurrentAngle = Mathf.Atan2(NormalizedMousePosition.y, NormalizedMousePosition.x)*Mathf.Rad2Deg ;

        //CurrentAngle = (CurrentAngle + 360 + (22.5f * (ChoicesDisplay.Count - 1)) -45f )%360 ;
        CurrentAngle = (CurrentAngle + 360)%360 ;

        Selection = (int) CurrentAngle / 45 ;

        Debug.Log(Selection + " " + CurrentAngle);
        return Selection ;
    }
}

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

    public async void SetActionWheel()
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
                //angle = 135f ; 
                choiceObject.mainCircle.fillAmount = angle / 360f;         
          
                //rotation.z = angle * i - (angle / ChoicesDisplay.Count); 
                rotation.z = 90f - (22.5f * (ChoicesDisplay.Count - 1)); 
                radianAngle = -1.5f;    

                //Debug.Log(angle + " = " + "180f - " + (180f / (ChoicesDisplay.Count - 1) / 2));
            } else {
                angle = 45f ; //(180f + (/*360f*/180f / (ChoicesDisplay.Count - 1) / 2)) / (ChoicesDisplay.Count - 1) ;
                choiceObject.mainCircle.fillAmount = angle / 360f ;  

                //float Angle0 = 360f - (45f * (ChoicesDisplay.Count - 1)) ;
                float Angle0 = 90f - (22.5f * (ChoicesDisplay.Count - 1));


                rotation.z = angle * i + Angle0 ; 
                //radianAngle = angle * i * Mathf.Deg2Rad - (angle * Mathf.Deg2Rad * 1f);                     
                radianAngle = rotation.z * Mathf.Deg2Rad - (angle * Mathf.Deg2Rad * 0.5f);                     
            }
            

            choiceObject.transform.localRotation = Quaternion.Euler(rotation);

            choiceObject.colorCircle.color = colors[i];

            choiceObject.textObject.text = ChoicesDisplay[i].NameActionFR;
            choiceObject.iconObject.sprite = ChoicesDisplay[i].IconAction;
        //    choiceObject.mainButton.onClick.AddListener(() => Debug.Log("Hey"));
            choiceObject.textObject.transform.rotation = Quaternion.identity;
            choiceObject.iconObject.transform.rotation = Quaternion.identity;

            //float radianAngle = angle * i * Mathf.Deg2Rad - (angle * 2 * Mathf.Deg2Rad * 0.5f);
                Debug.Log("2; " + angle + " " + radianAngle);            
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
}

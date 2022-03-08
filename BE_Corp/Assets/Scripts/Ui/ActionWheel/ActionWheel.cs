using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ActionWheelActionData
{
    public string name;
    public Sprite icon;
    public GameObject action;
}

public class ActionWheel : MonoBehaviour
{
    public List<ActionWheelActionData> choices = new List<ActionWheelActionData>();
    public GameObject choicePrefab;
    List<ActionWheelChoice> choiceObjects = new List<ActionWheelChoice>();

    public List<Color> colors = new List<Color>();


    void Start() 
    {
        for (int i = 0; i < choices.Count; i++)
        {
            ActionWheelChoice choiceObject = Instantiate(choicePrefab, transform).GetComponent<ActionWheelChoice>();
            choiceObjects.Add(choiceObject);
            Vector3 rotation = choiceObject.transform.localRotation.eulerAngles;
            float angle = 360.0f / choices.Count;
            rotation.z = angle * i;
            choiceObject.transform.localRotation = Quaternion.Euler(rotation);
            choiceObject.mainCircle.fillAmount = 1.0f / choices.Count;
            choiceObject.colorCircle.color = colors[i];

            choiceObject.textObject.text = choices[i].name;
            choiceObject.iconObject.sprite = choices[i].icon;
            choiceObject.mainButton.onClick.AddListener(() => Debug.Log("Hey"));
            choiceObject.textObject.transform.rotation = Quaternion.identity;
            choiceObject.iconObject.transform.rotation = Quaternion.identity;

            float radianAngle = angle * i * Mathf.Deg2Rad - (angle * Mathf.Deg2Rad * 0.5f);
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

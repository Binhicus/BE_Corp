using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.EventSystems;
using DG.Tweening ;

[System.Serializable]
public class ActionWheelActionData
{
    public string NameAction;
    public Sprite IconAction;
    public GameObject action;
}

public class ActionWheel : MonoBehaviour
{
    public List<ActionWheelChoiceData> ChoicesDisplay = new List<ActionWheelChoiceData>();
    public Transform ActionChoiceContainer ;
    public TextMeshProUGUI TitleCurrentActionChoice ;
    public GameObject choicePrefab;
    List<ActionWheelChoice> choiceObjects = new List<ActionWheelChoice>();

    public GameObject DialogueDisplayer ;

   /* public List<Color> colors = new List<Color>();*/

    private bool MouseHover = false ;
    private bool CanClick = false ;


    private RectTransform TransformParent ;
    private Canvas UICanvas ;
    private Camera UICamera ;

    public IAction TargetAction ;

    void Start() 
    {
        SetActionWheel();
    }

    private void OnEnable() 
    {
        SetActionWheelPos();        
        StartCoroutine(SetActionWheel()); 
    }
    

    public void DisableWheel()
    { 
        StartCoroutine(CloseWheel()); 
    }



    void SetActionWheelPos()
    {
        RectTransform TransformParent = transform.parent.GetComponent<RectTransform>();
        Canvas UICanvas = transform.parent.GetComponent<Canvas>();
        Camera UICamera = GameObject.Find("UI Camera").GetComponent<Camera>();       


        Vector2 AnchoredPos ;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(TransformParent, Input.mousePosition, UICanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : UICamera, out AnchoredPos);
       
        GetComponent<RectTransform>().anchoredPosition = AnchoredPos;
    }

    Vector2 MousePositionInScreen()
    {
        RectTransform TransformParent = transform.parent.GetComponent<RectTransform>();
        Canvas UICanvas = transform.parent.GetComponent<Canvas>();
        Camera UICamera = GameObject.Find("UI Camera").GetComponent<Camera>();       


        Vector2 MousePos ;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(TransformParent, Input.mousePosition, UICanvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : UICamera, out MousePos);
        return MousePos ;
    }

    IEnumerator SetActionWheel()
    {
        CanClick = false ;

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
            SetAngledPosition(choiceObject.IconObject.transform, ActionChoiceContainer.transform.position, radianAngle, 50f);
            choiceObject.IconObject.transform.GetComponent<RectTransform>().DOScale(new Vector3(0.75f, 0.75f, 0.75f), 0.125f);

            choiceObject.NameAction.text = ChoicesDisplay[i].NameActionFR;
            choiceObject.NameAction.transform.rotation = Quaternion.identity;    



            choiceObject.NameAction.GetComponent<RectTransform>().pivot = SetTextPivot(choiceObject.IconObject.GetComponent<RectTransform>());        
            SetAngledPosition(choiceObject.NameAction.transform, ActionChoiceContainer.transform.position, radianAngle, 105f);


            float ValueDecallage = (choiceObject.IconObject.GetComponent<RectTransform>().sizeDelta.x - choiceObject.IconObject.GetComponent<RectTransform>().sizeDelta.x / 4f) / 2f ;
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(0, 0)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(ValueDecallage, ValueDecallage);
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(0, 1f)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(ValueDecallage, -ValueDecallage);
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(1f, 0)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(-ValueDecallage, ValueDecallage);
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(1f, 1f)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(-ValueDecallage, -ValueDecallage);

            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(0f, 0.5f)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(ValueDecallage * 2f , 0f);
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(1f, 0.5f)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(-ValueDecallage * 2f , 0f);
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(0.5f, 0f)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, ValueDecallage);
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot == new Vector2(0.5f, 1f)) choiceObject.NameAction.GetComponent<RectTransform>().anchoredPosition += new Vector2(0f, -ValueDecallage);



            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot.x == 0) choiceObject.NameAction.alignment = TextAlignmentOptions.Left ;
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot.x == 0.5f) choiceObject.NameAction.alignment = TextAlignmentOptions.Center ;
            if(choiceObject.NameAction.GetComponent<RectTransform>().pivot.x == 1f) choiceObject.NameAction.alignment = TextAlignmentOptions.Right ;

            SetPartActionWheel(TargetAction, choiceObject.NameAction.text, choiceObject);
            yield return new WaitForSeconds(0.075f);            
        }

        CanClick = true ;
    }

    Vector2 SetTextPivot(Transform ReferencePosRect)
    {
        Vector2 NewPivot = new Vector2(0.5f, 0.5f) ; 
        // Set X Pivot
        if(ReferencePosRect.position.x < ActionChoiceContainer.GetComponent<RectTransform>().position.x) NewPivot.x += 0.5f ; 
        if(ReferencePosRect.position.x == ActionChoiceContainer.GetComponent<RectTransform>().position.x) NewPivot.x = 0.5f ; 
        if(ReferencePosRect.position.x > ActionChoiceContainer.GetComponent<RectTransform>().position.x) NewPivot.x -= 0.5f ;
        // Set Y Pivot
        if(ReferencePosRect.position.y - (32f * 1.5f) < ActionChoiceContainer.GetComponent<RectTransform>().position.y) NewPivot.y += 0.5f ; 

        if(ReferencePosRect.position.y + (32f * 1.5f) > ActionChoiceContainer.GetComponent<RectTransform>().position.y) NewPivot.y -= 0.5f ; 

        return NewPivot ;
    }
    

    void SetAngledPosition(Transform obj, Vector3 center, float angle, float radius)
    {
        Vector3 position = obj.position;
        position.x = center.x + Mathf.Cos(angle) * radius;
        position.y = center.y + Mathf.Sin(angle) * radius;
        obj.position = position;
    }

    void SetPartActionWheel(IAction TargetRef, string NamePartAction, ActionWheelChoice PartPrefab)
    {
        PartPrefab.TargetAction = TargetRef ;

        if(NamePartAction == "") PartPrefab.StateAction = ActionPossible.Rien ;
        if(NamePartAction == "Ouvrir" || NamePartAction == "Open") PartPrefab.StateAction = ActionPossible.Ouvrir ;
        if(NamePartAction == "Fermer" || NamePartAction == "Close") PartPrefab.StateAction = ActionPossible.Fermer ;
        if(NamePartAction == "Prendre" || NamePartAction == "Take") PartPrefab.StateAction = ActionPossible.Prendre ;
        if(NamePartAction == "Utiliser" || NamePartAction == "Use") PartPrefab.StateAction = ActionPossible.Utiliser ;
        if(NamePartAction == "Inspecter" || NamePartAction == "Inspect") PartPrefab.StateAction = ActionPossible.Inspecter ;
        if(NamePartAction == "Questionner" || NamePartAction == "Question") PartPrefab.StateAction = ActionPossible.Questionner ;
    }




    void Update() 
    {
        if(CanClick)
        {
            for (int CAW = 0; CAW < ActionChoiceContainer.transform.childCount; CAW++)
            {
                if(ActionChoiceContainer.transform.GetChild(CAW).GetComponent<ActionWheelChoice>().StateMouseOver == ActionOveringState.Overing && CAW != GetAngleMouseOvered()) ActionChoiceContainer.transform.GetChild(CAW).GetComponent<ActionWheelChoice>().StateOvering(false);
                if(ActionChoiceContainer.transform.GetChild(CAW).GetComponent<ActionWheelChoice>().StateMouseOver == ActionOveringState.Overing && CAW == GetAngleMouseOvered() && MouseOverBool() == false) ActionChoiceContainer.transform.GetChild(CAW).GetComponent<ActionWheelChoice>().StateOvering(false);
            }


            if(MouseOverBool())
            {
                if(GetAngleMouseOvered() >= 0 && GetAngleMouseOvered() < ActionChoiceContainer.transform.childCount && ActionChoiceContainer.transform.GetChild(GetAngleMouseOvered()).GetComponent<ActionWheelChoice>().StateMouseOver == ActionOveringState.NotOvering)
                {
                    ActionChoiceContainer.transform.GetChild(GetAngleMouseOvered()).GetComponent<ActionWheelChoice>().StateOvering(true);
                    TitleCurrentActionChoice.text = ChoicesDisplay[GetAngleMouseOvered()].NameActionFR ;
                }
            } else {
                if(Input.GetMouseButtonDown(0)) DisableWheel();
            }
        }

    }



    private Vector2 NormalizedMousePosition ;
    private float CurrentAngle ;
    private int Selection ;

    int GetAngleMouseOvered()
    {
        NormalizedMousePosition = new Vector2((MousePositionInScreen().x - GetComponent<RectTransform>().anchoredPosition.x ) , (MousePositionInScreen().y -  GetComponent<RectTransform>().anchoredPosition.y));
        CurrentAngle = Mathf.Atan2(NormalizedMousePosition.y, NormalizedMousePosition.x) * Mathf.Rad2Deg ;

        CurrentAngle = (CurrentAngle + 360f + (360 / ChoicesDisplay.Count)) % 360f ;

        Selection = (int) CurrentAngle / (360 / ChoicesDisplay.Count) ;


        return Selection ;
    }




    IEnumerator CloseWheel()
    {
        CanClick = false ;

        for (int i = 0; i < ActionChoiceContainer.transform.childCount; i++)
        {
            ActionChoiceContainer.transform.GetChild(i).DOScale(Vector3.zero, 0.08f);
            yield return new WaitForSeconds(0.06f);            
        }

        gameObject.SetActive(false);
    }

    bool MouseOverBool()
    {
        float radius = 65f ;

        Vector2 Center = GetComponent<RectTransform>().anchoredPosition ;

        float ValueRacine = Mathf.Sqrt( Mathf.Pow(MousePositionInScreen().x - Center.x, 2) + Mathf.Pow(Center.y - MousePositionInScreen().y, 2)/*(Center.y - MosPos.y)*/) ;

        if(ValueRacine < radius) return true ;
        else return false ;
    }

    

}

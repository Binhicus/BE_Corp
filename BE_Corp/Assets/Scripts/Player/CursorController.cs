using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum CursorType { Default, Object, SceneChange, Observe }

public class CursorController : Singleton<CursorController>
{

    //public Texture2D cursorClicked;

    public bool canInteract;
    public Camera mainCamera;

    [Header("Base")]    
    public Texture2D cursor;
    public Texture2D defaultCursor;

    [Header("Object")]
    public Texture2D objectCursor;

    [Header("SceneChange")]
    public Texture2D sceneChangeCursor;

    [Header("Loupe")]
    public Texture2D observeCursor;

    [Header("Scripts refs")]
    public ActionWheel ActionWheelScript ;
    public CursorControls controls;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        controls = new CursorControls();
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
        mainCamera = Camera.main;
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }
    // Update is called once per frame
    private void Start()
    {
        canInteract = true;
        controls.Mouse.Click.started += _ => StartedClick();
        controls.Mouse.Click.performed += _ => EndedClick(); 
    }

    private void StartedClick()
    {
        //ChangeCursor(cursorClicked);
    }

    private void EndedClick()
    {
        DetectObject();
        ChangeCursor(cursor);
    }
    private void DetectObject()
    {
        if (canInteract)
        {
            #region RayCastBasique
            Ray ray = mainCamera.ScreenPointToRay(controls.Mouse.Position.ReadValue<Vector2>());
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    IClicked click = hit.collider.gameObject.GetComponent<IClicked>();
                    //* IItemInventaire item = hit.collider.gameObject.GetComponent<IItemInventaire>();
                    if (click != null) click.OnClickAction();
                    //if (click == null) return;
                    //* if (item != null) Inventaire.Instance.AddItem(item);
                    //Debug.Log("3D Hit: " + hit.collider.tag + " " + hit.collider.gameObject);
                    //Debug.DrawRay(transform.position, Vector3.forward, Color.green);
                }
            }
            #endregion

            #region RecupTout
            /*RaycastHit[] hits = Physics.RaycastAll(ray, 200);
            for (int i = 0; i < hits.Length; i++)
            {
                if(hits[i].collider != null)
                {
                    Debug.Log("3D Hit All:" + hits[i].collider.tag); 
                }
            }*/
            #endregion

            #region ChoixSize
            /*RaycastHit[] hitsNonAlloc = new RaycastHit[1];
            int numberOfHits = Physics.RaycastNonAlloc(ray, hitsNonAlloc);
            for (int i = 0; i < numberOfHits; i++)
            {
                if (hits[i].collider != null)
                {
                    Debug.Log("3D Hit Non Alloc: " + hitsNonAlloc[i].collider.tag);
                }
            }*/
            #endregion
        }
    }
    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursorType.width / 2, cursorType.height / 2);  // à mettre si le hotspot du curseur est au centre du sprite
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }

    public void ChangeCursor(CursorType cursorType)
    {
        Texture2D cursorTexture = GetCursorTexture(cursorType);
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    Texture2D GetCursorTexture(CursorType cursorType)
    {
        if (!isMouseOverUI())
        { 
            if (cursorType == CursorType.Default) return defaultCursor;
            if (cursorType == CursorType.Object) return objectCursor;
            if (cursorType == CursorType.SceneChange) return sceneChangeCursor;
            if (cursorType == CursorType.Observe) return observeCursor;
        }
        else if (isMouseOverUI())
        {
            return defaultCursor;
        }
        return null;
    }

    private bool isMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    public void BoolTrueSetter()
    {
        Invoke("BoolEqualsTrue", 0.3f);
    }

    private void BoolEqualsTrue()
    {
        canInteract = true;
    }
    public void BoolFalseSetter()
    {
        canInteract = false;
    }
}

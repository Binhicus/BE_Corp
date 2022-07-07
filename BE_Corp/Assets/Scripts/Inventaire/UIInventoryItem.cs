using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    //public Camera mainCamera;
    private CursorController cursorController;
    public string objectID;
    private Transform uiPos;
    public GameObject Inventaire, mouseOn, mouseOff;
    //public GameObject animToSpawn;
    public MouseOnInventory mouseOnInventory;

    [Header("Sounds")]
    public AudioSource fusionSound;
    public AudioSource deniedSound;
    
    //public Camera cam;

    Vector3 offset;

    private void Awake()
    {
        // mainCamera = CamScript.camInstance.GetComponent<Camera>();
        //cam = GameObject.Find("InventoryCam").GetComponent<Camera>();
       Inventaire=GameObject.Find("Inventaire");
       mouseOnInventory=GameObject.Find("Mouse On").GetComponent<MouseOnInventory>();
        mouseOn = GameObject.Find("Mouse On");
        mouseOff = GameObject.Find("Mouse Off");
        PlayerPrefs.SetInt("DraggingItem", 0);
    }
    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = MouseWorldPosition() + offset;
        mouseOn.SetActive(false);
        mouseOff.SetActive(false);
        PlayerPrefs.SetInt("DraggingItem", 1);
        CursorController.Instance.BoolFalseSetter();
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        CursorController.Instance.BoolTrueSetter();
        mouseOn.SetActive(true);
        mouseOff.SetActive(true);
        PlayerPrefs.SetInt("DraggingItem", 0);
        Ray ray = Camera.main.ScreenPointToRay(CursorController.Instance.controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        bool hitSomething = false;
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider != null)
            {

                IHasItemInteraction[] itemInteractions = hits[i].collider.GetComponents<IHasItemInteraction>();
                foreach(var interaction in itemInteractions)
                {
                    if (interaction.inventoryItemID == objectID)
                    {
                        hitSomething = true;
                        interaction.ItemDropAnim(); ////////////////////
                        interaction.DoItemInteraction();
                        fusionSound.Play();
                        GetComponent<Image>().enabled = false;
                        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                        Destroy(gameObject.transform.GetChild(0).gameObject);
                        /*if (gameObject.transform.GetChild(0) == true)
                        {
                            gameObject.transform.GetChild(0).gameObject.SetActive(false);
                            Debug.Log("eteint");
                        }
                        if (gameObject.transform.GetChild(0) == false)
                        {
                            gameObject.transform.GetChild(1).gameObject.SetActive(false);
                            Debug.Log("nuebe 92i");
                        }
                        if (gameObject.transform.GetChild(0) == false && gameObject.transform.GetChild(1) == false)
                        {
                            gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        }*/
                    }
                }
            }           
        } 
        
        if (!hitSomething) 
        {
            transform.localPosition = Vector3.zero;
            Debug.Log("hihihi je vais serrer???");
            deniedSound.Play();
            StartCoroutine(coroutineA());
        }

        /*
        // Remplacer "true" par la condition (raycast scène)
        if (true)
        {
           // On a visé un objet de la scène interactif (serrure par ex)
           Debug.Log("dosomething");
           GetComponent<Image>().enabled = false;
        }
        else
       
       transform.localPosition = Vector3.zero;*/

    IEnumerator coroutineA()

        {
        mouseOnInventory.isOn=false;
        Inventaire.GetComponent<RectTransform>().anchoredPosition = new Vector3(-79, 0,0);
        yield return new WaitForSeconds(1.0f);
        mouseOnInventory.isOn=true;
        Inventaire.GetComponent<RectTransform>().anchoredPosition = new Vector3(100, 0,0);
        
        }
        
    }
}

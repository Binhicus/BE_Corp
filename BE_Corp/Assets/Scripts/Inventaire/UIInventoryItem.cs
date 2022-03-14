using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public Camera mainCamera;
    private CursorController cursorController;
    public string objectID;

    private void Awake()
    {
        mainCamera = CamScript.camInstance.GetComponent<Camera>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Ray ray = Camera.main.ScreenPointToRay(CursorController.Instance.controls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit[] hits = Physics.RaycastAll(ray, 200);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider != null)
            {
                IHasItemInteraction[] itemInteractions = hits[i].collider.GetComponents<IHasItemInteraction>();
                foreach(var interaction in itemInteractions)
                {
                    if (interaction.inventoryItemID == objectID)
                        interaction.DoItemInteraction();
                }
            }
        }

        // Remplacer "true" par la condition (raycast scène)
        if (true)
        {
            // On a visé un objet de la scène interactif (serrure par ex)
            Debug.Log("dosomething");
            GetComponent<Image>().enabled = false;
        }
        else
            
        transform.localPosition = Vector3.zero;
    }
}

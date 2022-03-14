using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            UIInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<UIInventoryItem>();
            if (item != null)
            {
                item.OnEndDrag(eventData);
            }

        }
    }
}

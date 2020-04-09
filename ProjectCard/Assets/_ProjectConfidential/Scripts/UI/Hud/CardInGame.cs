using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInGame : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Specs")]
    [SerializeField] private bool isDraggable = false;

    private Vector3 initPosition = Vector3.zero;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.DrawLine(transform.position, eventData.position, Color.yellow, 100f);
        initPosition = transform.position;
        isDraggable = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        RectTransform lEventTransform = eventData.pointerEnter.transform as RectTransform;

        RectTransform rect = GetComponent<RectTransform>();
        Vector3 globalMousePos;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(lEventTransform, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            rect.position = globalMousePos;
            rect.rotation = lEventTransform.rotation; 
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = initPosition;
    }
}

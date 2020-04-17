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
        initPosition = transform.position;
        isDraggable = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        RectTransform lEventTransform = eventData.pointerEnter.transform as RectTransform;

        RectTransform rect = GetComponent<RectTransform>();
        Vector3 lGlobalMousePos;

        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(lEventTransform, eventData.position, eventData.pressEventCamera, out lGlobalMousePos))
        {
            rect.position = lGlobalMousePos;
            rect.rotation = lEventTransform.rotation;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ///////////////////// A changer dans le futur ////////////////////

        RaycastHit hit;

        Camera camera = GameObject.Find("CameraPlateau").GetComponent<Camera>();
        Vector3 lGlobalPos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,camera.farClipPlane));
        
        Debug.DrawRay(camera.transform.position, (lGlobalPos - camera.transform.position).normalized * 300, Color.yellow, 100f);
        //Debug.DrawLine(lScreenToWorld, camera.transform.position , Color.yellow, 100f);

        if (Physics.Raycast(camera.transform.position, lGlobalPos - camera.transform.position, out hit, Mathf.Infinity))
        {
            Debug.Log("[RaycastDrag]" + " " + hit.transform);
            ArenaPath lArena = hit.transform.GetComponent<ArenaPath>();

            if (lArena)
            {
                if (lArena.Settings.IsDraggableForPlayer)
                {
                    Debug.Log("[DragCard]" + " isOnField");
                    GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Mobile lMobile = test.AddComponent(typeof(Mobile)) as Mobile;
                    lMobile.Path = lArena;
                }
                else
                    transform.position = initPosition;
            }
        }
        else
            transform.position = initPosition;
    }
}

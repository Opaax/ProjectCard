using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInGame : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("Specs")]
    [SerializeField] private bool isDraggable = false;

    private Vector3 initPosition = Vector3.zero;

    private RectTransform rect = default;

    private float baseWidth = 0;
    private float baseHeight = 0;

    private void Start()
    {
        rect = GetComponent<RectTransform>();

        baseWidth = rect.sizeDelta.x;
        baseHeight = rect.sizeDelta.y;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        initPosition = transform.position;
        isDraggable = true;

        StartCoroutine(StartDragRoutine());
    }

    private IEnumerator StartDragRoutine()
    {
        float lElapsedTime = 0;
        float lTimeEffect = 0.1f;

        while (lElapsedTime <= lTimeEffect)
        {
            lElapsedTime += Time.deltaTime;

            rect.sizeDelta = new Vector2(Mathf.Lerp(baseWidth, baseWidth * 1.2f, lElapsedTime / lTimeEffect), Mathf.Lerp(baseHeight, baseHeight * 1.2f, lElapsedTime / lTimeEffect));

            yield return null;
        }

        lElapsedTime = 0;
        lTimeEffect = 0.5f;

        while(lElapsedTime <= lTimeEffect)
        {
            lElapsedTime += Time.deltaTime;

            rect.sizeDelta = new Vector2(Mathf.Lerp(rect.sizeDelta.x, baseWidth * 0.75f, lElapsedTime / lTimeEffect), Mathf.Lerp(rect.sizeDelta.y, baseHeight * 0.75f, lElapsedTime / lTimeEffect));

            yield return null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable) return;

        if (!eventData.pointerEnter) return;

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
                {
                    StartCoroutine(BackToInitPosRoutine());
                }
            }
            else
            {
                StartCoroutine(BackToInitPosRoutine());
            }
        }
        else
        {
            StartCoroutine(BackToInitPosRoutine());
        }
    }

    private IEnumerator BackToInitPosRoutine()
    {
        Debug.Log("RETURN");

        float lElapsedTime = 0;
        float lTimeToEffect = 1;

        while(lElapsedTime <= lTimeToEffect)
        {
            lElapsedTime += Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, initPosition, lElapsedTime / lTimeToEffect);

            yield return null;
        }

        yield break;
    }
}

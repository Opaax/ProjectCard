using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraForceRatio : MonoBehaviour
{
    [SerializeField] private Vector2 wantedAspect = Vector2.zero;
    [Space]
    [SerializeField] private bool isLandScape = true;
    [SerializeField] private bool isCheckChangingResolution = true;

    private float targetAspect = 0;
    private float windowAspect = 0;

    private Vector2 currentResolution = Vector2.zero;

    private void Start()
    {
        currentResolution = new Vector2(Screen.width, Screen.height);
        ChangeAspect();
    }

    private void Update()
    {
        if (!isCheckChangingResolution) return;

        if(currentResolution.x != Screen.width || currentResolution.y != Screen.height)
        {
            currentResolution = new Vector2(Screen.width, Screen.height);
            ChangeAspect();
        }
    }

    private void ChangeAspect()
    {
        if (isLandScape)
            targetAspect = (float)wantedAspect.x / (float)wantedAspect.y;
        else
            targetAspect = (float)wantedAspect.y / (float)wantedAspect.x;

        windowAspect = (float)Screen.width / (float)Screen.height;

        float lScaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (lScaleHeight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = lScaleHeight;
            rect.x = 0;
            rect.y = (1.0f - lScaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            float scalewidth = 1.0f / lScaleHeight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}

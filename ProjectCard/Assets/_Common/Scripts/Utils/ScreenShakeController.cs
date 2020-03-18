using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShakeController : MonoBehaviour
{
    private Transform transformToShake;

    private Vector3 backPosition;
    private Vector3 positionScreenShake;

    private bool backToStartPos;

    private float timeShake;
    private float timeRemainingShake;
    private float powerShake;
    private float ratio;

    private Action doAction;
    private void Awake()
    {
        SetModeVoid();
    }

    private void SetModeVoid()
    {
        doAction = DoActionVoid;
    }

    private void DoActionVoid()
    {
    }

    // Update is called once per frame
    void Update()
    {
        doAction();
    }

    /// <summary>
    /// Init the Shake
    /// </summary>
    /// /// <param name="shakeTransform">Set The Target you want to shake</param> 
    /// <param name="time">Set the duration of shake</param> 
    /// <param name="power">Set the power of the shake</param>
    /// <param name="isTargeted">if the target object shaked haven't late Reposition put false and on the last frame the target will return on his start position</param>
    /// <param name="isTargeted">if is true the power of shake will fade to increase / if is false the power will fade to decrease</param>
    public void StartShake(Transform shakeTransform, float time, float power, bool isTargeted = false, bool isInverseShake = false)
    {
        transformToShake = shakeTransform;

        timeShake = time;
        timeRemainingShake = time;
        powerShake = power;

        if (!isTargeted)
        {
            backToStartPos = true;
            backPosition = transformToShake.position;
            positionScreenShake = backPosition;
        }

        if (isInverseShake)
        {
            SetModeInverseShake();
            timeRemainingShake = 0f;
        }
        else
            SetModeNormalShake();
    }

    private void SetModeNormalShake()
    {
        doAction = DoActionNormalShake;
    }

    private void SetModeInverseShake()
    {
        doAction = DoActionInverseShake;
    }

    private void DoActionNormalShake()
    {
        if (timeRemainingShake > 0)
        {
            timeRemainingShake -= Time.deltaTime;
            ratio = timeRemainingShake / timeShake;

          
            float xAmout = UnityEngine.Random.Range(-1f, 1f) * Mathf.Lerp(0f, powerShake, ratio);
            float yAmout = UnityEngine.Random.Range(-1f, 1f) * Mathf.Lerp(0f, powerShake, ratio);

            if (backToStartPos)
                transformToShake.position = positionScreenShake + new Vector3(xAmout, yAmout, 0);
            else
                transformToShake.position += new Vector3(xAmout, yAmout, 0);
        }
        else
        {
            if (transformToShake == null) return;

            transformToShake.position = backPosition;
            transformToShake = null;

            SetModeVoid();
        }
    }

    private void DoActionInverseShake()
    {
        if (timeRemainingShake < timeShake)
        {
            timeRemainingShake += Time.deltaTime;
            ratio = timeRemainingShake / timeShake;

            float xAmout = UnityEngine.Random.Range(-1f, 1f) * Mathf.Lerp(0f, powerShake, ratio);
            float yAmout = UnityEngine.Random.Range(-1f, 1f) * Mathf.Lerp(0f, powerShake, ratio);

            if (backToStartPos)
                transformToShake.position = positionScreenShake + new Vector3(xAmout, yAmout, 0);
            else
                transformToShake.position += new Vector3(xAmout, yAmout, 0);
        }
        else
        {
            if (transformToShake == null) return;

            transformToShake.position = backPosition;
            transformToShake = null;

            SetModeVoid();
        }
    }
}

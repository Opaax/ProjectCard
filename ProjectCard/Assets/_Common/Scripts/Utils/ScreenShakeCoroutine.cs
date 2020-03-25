///-----------------------------------------------------------------
/// Author : Enguerran COBERT
/// Date : 17/12/2019 12:51
///-----------------------------------------------------------------

using System.Collections;
using UnityEngine;

namespace Com.DefaultCompany.ToolsFab.FabTools {
	public class ScreenShakeCoroutine : MonoBehaviour {

        private Transform thingToShake;

        private float timeToShake = 0;
        private float timeRemaining = 0;
        private float powerOfShake = 0;
        private float ratio = 0;

        private Coroutine coroutine;

        public void InitShake(Transform transformToShake, float time, float power)
        {
            thingToShake = transformToShake;
            timeToShake = time;
            timeRemaining = 0;
            powerOfShake = power;

            if (coroutine != null)
                coroutine = null;

            coroutine = StartCoroutine(NormalShake());
        }

        private IEnumerator NormalShake()
        {
            timeRemaining += Time.deltaTime;

            while(timeRemaining < timeToShake)
            {
                float xAmout = UnityEngine.Random.Range(-1f, 1f) * Mathf.Lerp(0f, powerOfShake, ratio);
                float yAmout = UnityEngine.Random.Range(-1f, 1f) * Mathf.Lerp(0f, powerOfShake, ratio);

                yield return null;
            }

            timeToShake = 0;
            timeRemaining = 0;
            powerOfShake = 0;
            thingToShake = null;

            yield break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLifetimeTimer
{
    public float Seconds;

    public GameObjectLifetimeTimer(float seconds)
    {
        Seconds = seconds;
    }

    public void StartTimer(MonoBehaviour context)
    {
        context.StartCoroutine(Routine());

        IEnumerator Routine()
        {
            yield return new WaitForSeconds(Seconds);
            Object.Destroy(context.gameObject);
        }
    }
}

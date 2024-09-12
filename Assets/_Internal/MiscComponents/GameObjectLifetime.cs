using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectLifetime
{
    public GameObjectLifetime(MonoBehaviour context, float seconds)
    {
        context.StartCoroutine(Routine());

        IEnumerator Routine()
        {
            yield return new WaitForSeconds(seconds);
            Object.Destroy(context.gameObject);
        }
    }
}

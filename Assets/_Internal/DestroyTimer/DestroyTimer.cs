using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float Time = 10f;

    private void Start()
    {
        StartCoroutine(Routine());

        IEnumerator Routine()
        {
            yield return new WaitForSeconds(Time);
            Destroy(gameObject);
        }
    }
}

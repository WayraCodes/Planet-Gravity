using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Script : MonoBehaviour
{
    public float SecondsToLive;

    private void Start()
    {
        StartCoroutine(DeathCounter());
    }

    IEnumerator DeathCounter ()
    {
        yield return new WaitForSeconds(SecondsToLive);
        Destroy(this.gameObject);
    }
}

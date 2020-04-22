using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController_Script : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    private bool IsFinished = true;

    private void Start()
    {
        c1.SetActive(true);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(false);
    }

    private void Update()
    {
        if (IsFinished == true)
        {
            StartCoroutine(Switch());
        }
    }

    IEnumerator Switch()
    {
        IsFinished = false;
        yield return new WaitForSeconds(10);
        c1.SetActive(false);
        c2.SetActive(true);
        yield return new WaitForSeconds(10);
        c2.SetActive(false);
        c3.SetActive(true);
        yield return new WaitForSeconds(10);
        c3.SetActive(false) ;
        c4.SetActive(true);
        yield return new WaitForSeconds(10);
        c4.SetActive(false);
        c1.SetActive(true);
        IsFinished = true;
    }
}

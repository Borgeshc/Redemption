using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnObject : MonoBehaviour
{
    public GameObject objectToEnable;
    public float time;

    void OnEnable()
    {
        StartCoroutine(TurnOnAfter());
    }

    IEnumerator TurnOnAfter()
    {
        yield return new WaitForSeconds(time);
        objectToEnable.SetActive(true);
    }
}

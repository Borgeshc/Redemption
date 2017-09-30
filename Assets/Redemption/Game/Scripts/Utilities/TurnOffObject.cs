using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffObject : MonoBehaviour
{
    public float time;
    
	void OnEnable ()
    {
        StartCoroutine(TurnOffAfter());
	}

    IEnumerator TurnOffAfter()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}

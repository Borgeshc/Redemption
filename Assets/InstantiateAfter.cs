using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateAfter : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public float instantiateAfter;

    private void OnEnable()
    {
        StartCoroutine(InstantiateObject());
    }

    public IEnumerator InstantiateObject()
    {
        print("happens");
        yield return new WaitForSeconds(instantiateAfter);
        Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
	}
}

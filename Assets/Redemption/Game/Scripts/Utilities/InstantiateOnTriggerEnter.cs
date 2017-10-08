using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnTriggerEnter : MonoBehaviour
{
    public GameObject objectToInstantiate;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Player"))
        {
            Instantiate(objectToInstantiate, other.transform.position, Quaternion.identity, other.transform);
            Destroy(gameObject);
        }
    }
}

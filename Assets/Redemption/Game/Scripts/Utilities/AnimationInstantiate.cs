using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInstantiate : MonoBehaviour
{
    public GameObject objectToInstantiate;

    public void TriggerInstantiation()
    {
        Instantiate(objectToInstantiate, transform.position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationActivate : MonoBehaviour
{
    public GameObject objectToSetActive;

    public void ActivateObject()
    {
        objectToSetActive.SetActive(true);
    }

    public void DeActivateObject()
    {
        objectToSetActive.SetActive(false);
    }
}

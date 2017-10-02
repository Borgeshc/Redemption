using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed;

	void LateUpdate ()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, followSpeed * Time.deltaTime);
	}
}

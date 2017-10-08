using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootPlayer : MonoBehaviour
{
	void Start ()
    {
        PlayerMovement.canMove = false;
	}

    private void OnDisable()
    {
        PlayerMovement.canMove = true;
    }
}

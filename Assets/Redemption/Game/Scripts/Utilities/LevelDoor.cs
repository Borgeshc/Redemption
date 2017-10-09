using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDoor : Interactable
{
    public string nextLevelName;

    public override void Interact()
    {
        print("Next Level");
        SceneManager.LoadScene(nextLevelName);
    }
}

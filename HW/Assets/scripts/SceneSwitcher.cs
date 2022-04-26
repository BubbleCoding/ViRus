using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : InteractableTrigger
{
    public string loadLevel;

    private void Start() { Time.timeScale = 1; }
    public override void Pressed()
    {
        SceneManager.LoadScene(loadLevel);
    }
}

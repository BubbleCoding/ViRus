using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PointerTest : MonoBehaviour
{
    public string loadLevel;
    public int startsec;

    private void Start() {
        Time.timeScale = 1;
        Invoke("SwitchScene", startsec);
        
    }

    public void SwitchScene()
        {
        SceneManager.LoadScene(loadLevel);

    }
}

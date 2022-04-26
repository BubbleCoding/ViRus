using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : InteractableTrigger
{
    public GameObject myobject;
    public GameObject myobject2;
    public GameObject myobject3;
    public GameObject myobject4;

    public int delay;
    public int Bodydelay;

    public string loadLevel;

    public override void Pressed()
    {
        Time.timeScale = 1;
        myobject.SetActive(true);
        myobject2.SetActive(false);
        Invoke("SwitchBody", Bodydelay);
        Invoke("SwitchScene", delay);
    }

    public void SwitchBody() {
        myobject3.SetActive(true);
        myobject4.SetActive(false);
    }
    public void SwitchScene()
    {
        SceneManager.LoadScene(loadLevel);

    }
}

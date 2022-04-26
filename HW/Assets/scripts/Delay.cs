using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Delay : MonoBehaviour
{
    public GameObject myobject;
    public int delay;
    private void Start()
    {
        Time.timeScale = 1;
        Invoke("activate", delay);

    }

    public void activate()
    {
        myobject.SetActive(true);

    }
}

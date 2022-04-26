using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymptomSwitcher : InteractableTrigger
{
    public GameObject myobject;
    public GameObject myobject2;
    public GameObject myobject3;
    public GameObject myobject4;
    public bool activateme = true;

    public override void Pressed()
    {
        myobject.SetActive(activateme);
        myobject2.SetActive(!activateme);
        myobject3.SetActive(activateme);
        myobject4.SetActive(!activateme);

        activateme = !activateme;
    }
}
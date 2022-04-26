using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateBrain : InteractableTrigger
{
    public float rotateSpeed = 90f;
    public bool rotating = false;

    public override void Pressed()
    {
        rotating = !rotating;
        if(rotating == true) {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
       
    }

    }
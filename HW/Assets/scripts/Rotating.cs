using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotateSpeed = 90f;
    public bool rotating = true;

    public void Update()
    {
        if (rotating)
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.Self);
    }

    public void rotateToggle() {
        rotating = !rotating;
    }
}
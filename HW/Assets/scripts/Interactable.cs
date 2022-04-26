using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{


    public virtual void Pressed()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        bool flip = !renderer.enabled;

        renderer.enabled = flip;

    }

    public void Update() {

    }
}
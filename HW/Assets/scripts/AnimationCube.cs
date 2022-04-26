using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCube : InteractableTrigger
{
    private Animator anim;
    private bool playing = true;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Time.timeScale = 1;
    }
    public override void Pressed()
    {
        
        anim.Play("Take 001");

        playing = !playing;
        if (playing)
        {
            anim.speed = 1;
        }
        else
        {
            anim.speed = 2;
        }
    }
}
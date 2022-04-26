using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_script : InteractableTrigger
{
    public void play_sound(int s)
    {
        AudioManager.instance.s_playsound(s);
    }
    
}

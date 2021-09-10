using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions 
{
    public static Action<bool> Aim;
    public static Action<float> HandleHealthChanged;
    public static Action<Guns> HandleAmmoChanged;
    public static Action HandleScoreChanged;
    public static Action Death;
    public static Action<string> DisplayPickUpMessage;
    public static Action DisplayPauseMenu;
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuMusic : Sounds
{
    private void Start()
    {
        PlaySound(sounds[0], 1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuMusic : Sounds
{

    //Музыка в главном меню
    private void Start()
    {
        PlaySound(sounds[0], 1f);
    }
}

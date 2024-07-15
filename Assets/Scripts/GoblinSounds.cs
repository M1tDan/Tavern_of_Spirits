using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinSounds : Sounds
{
    private int DuringSong;


    //Фоновая музыка в игре
    private void Start()
    {
        DuringSong = Random.Range(0, 1);
        if(DuringSong == 0)
        {
            PlaySound(sounds[0], 1f);
        }
        else
        {
            PlaySound(sounds[1], 1f);
        }
    }
}

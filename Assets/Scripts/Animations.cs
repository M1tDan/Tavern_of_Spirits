using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public GameObject Goblin1, Goblin2;

    void Start()
    {
        StartCoroutine(GoblinIdleAnimation());
    }

    IEnumerator GoblinIdleAnimation()
    {
        while (true)
        {
            Goblin1.SetActive(true);
            Goblin2.SetActive(false);
            yield return new WaitForSeconds(1);
            Goblin1.SetActive(false);
            Goblin2.SetActive(true);
            yield return new WaitForSeconds(1);
        }
    }
}

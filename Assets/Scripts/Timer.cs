using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject NextDay;

    public float timerSpeed = 0.5f;
    private int minutes = 0;
    private int hours = 6;
    private float currentArrow = 136f;
    public int pause = 1;
    public TMP_Text _TimerText;
    [SerializeField] private int delta = 0;
    public GameObject ArrowPivot;

    IEnumerator DayTimer()
    {
        while (pause == 1)
        {
            if (minutes == 59)
            {
                hours = hours + 1;
                minutes = -1;
            }
            minutes += delta;
            _TimerText.text = hours.ToString("D2") + ":" + minutes.ToString("D2");
            currentArrow = currentArrow - 0.3f;
            ArrowPivot.transform.rotation = Quaternion.Euler(0, 0, currentArrow);
            if (hours == 21)
            {
                pause = 0;
                NextDay.SetActive(true);
            }
            yield return new WaitForSeconds(timerSpeed);
        }
    }

    private void Start()
    {
        StartCoroutine(DayTimer());
        ArrowPivot.transform.rotation = Quaternion.Euler(0, 0, 136);
    }
}

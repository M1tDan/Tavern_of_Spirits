using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject NextDay; //Кнопка окончания "смены", появляется в конце дня по истечении таймера

    private float timerSpeed = 0.2f;
    private int minutes = 0;
    private int hours = 6;
    public int pause = 1;
    public TMP_Text _TimerText, currentDayText;
    [SerializeField] private int currentDay = 1;

    private float hoursForTimer = 900; //Время рабочего дня в минутах
    public Slider TimerSlider;

    private const string DayNumber = "DayNumber"; //Номер дня по счёту

    //Таймер
    IEnumerator DayTimer()
    {
        while (pause == 1)
        {
            if (hours == 6 + hoursForTimer/60)
            {
                pause = 0;
                NextDay.SetActive(true);
                PlayerPrefs.SetInt(DayNumber, currentDay + 1);
                PlayerPrefs.Save();
            }
            if (minutes == 60)
            {
                hours = hours + 1;
                minutes = 0;
            }
            if (minutes % 5 == 0)
            {
                _TimerText.text = hours.ToString("D2") + ":" + minutes.ToString("D2");
            }
            yield return new WaitForSeconds(timerSpeed);
            minutes += 1;
            TimerSlider.value = ((hours * 60) + minutes) - 360;
        }
    }

    private void Start()
    {
        PlayerPrefs.DeleteKey("DayNumber"); //Закоментировать строку если не нужно обнулять дни
        TimerSlider.maxValue = hoursForTimer;
        StartCoroutine(DayTimer());
        if(PlayerPrefs.GetInt("DayNumber") == 0)
            currentDay = 1;
        else
            currentDay = PlayerPrefs.GetInt("DayNumber");
        currentDayText.text = "День: " + currentDay.ToString();
    }
}

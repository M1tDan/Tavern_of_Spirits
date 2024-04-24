using System;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    // Массивы для стульев, столешниц и ножек столов
    private GameObject[] chairArray1, chairArray2, chairArray3;
    private GameObject[] tableTopArray1, tableTopArray2, tableTopArray3;
    private GameObject[] tableLegArray1, tableLegArray2, tableLegArray3;

    // Списки для стульев, столешниц и ножек столов
    private List<GameObject> chairs1, chairs2, chairs3;
    private List<GameObject> tops1, tops2, tops3;
    private List<GameObject> legs1, legs2, legs3;

    public GameObject ModMenu, Joystick, HandButton, ModMenuButton, PreviousMenuButton;
    public GameObject OpenBuildTablesMenuButton, OpenBuildInterierMenuButton, MainBuildMenu, TablesMenu, InteriersMenu;
    public GameObject ChairColorButton, TableTopColorButton, TableLegColorButton, ChairColorMenu, TableTopColorMenu, TableLegColorMenu;

    // Словарь для цветов стульев
    private Dictionary<int, UnityEngine.Color> chairColors = new Dictionary<int, UnityEngine.Color>
    {
        { 1, new UnityEngine.Color(0.9811321f, 0.9247375f, 0.50445f) },
        { 2, new UnityEngine.Color(0.8490566f, 0.8490566f, 0.8490566f) },
        { 3, new UnityEngine.Color(0.8784314f, 0.5568628f, 0.3784314f) },
        { 4, new UnityEngine.Color(0.6896552f, 0.4431373f, 0.3137255f) },
        { 5, new UnityEngine.Color(0.8235294f, 0.6901961f, 0.1882353f) },
        { 6, new UnityEngine.Color(0.5333333f, 0.3254902f, 0.2156863f) },
        { 7, new UnityEngine.Color(0.8509804f, 0.5529412f, 0.3176471f) }
    };

    // Ключи для PlayerPrefs
    private const string lastChairKey = "LastChairIndex";
    private const string lastTopKey = "LastTopIndex";
    private const string lastLegKey = "LastLegIndex";

    private const string lastChairColorKey = "LastChairColorIndex";
    private const string lastTableTopColorKey = "LastTableTopColorIndex";
    private const string lastTableLegColorKey = "LastTableLegColorIndex";

    private void Start()
    {
        // Найти ровые объекты по тегам и инициализировать массивы и списки
        chairArray1 = GameObject.FindGameObjectsWithTag("Chair1");
        chairArray2 = GameObject.FindGameObjectsWithTag("Chair2");
        chairArray3 = GameObject.FindGameObjectsWithTag("Chair3");

        tableTopArray1 = GameObject.FindGameObjectsWithTag("Table-top1");
        tableTopArray2 = GameObject.FindGameObjectsWithTag("Table-top2");
        tableTopArray3 = GameObject.FindGameObjectsWithTag("Table-top3");

        tableLegArray1 = GameObject.FindGameObjectsWithTag("Table-leg1");
        tableLegArray2 = GameObject.FindGameObjectsWithTag("Table-leg2");
        tableLegArray3 = GameObject.FindGameObjectsWithTag("Table-leg3");

        chairs1 = new List<GameObject>(chairArray1);
        chairs2 = new List<GameObject>(chairArray2);
        chairs3 = new List<GameObject>(chairArray3);

        tops1 = new List<GameObject>(tableTopArray1);
        tops2 = new List<GameObject>(tableTopArray2);
        tops3 = new List<GameObject>(tableTopArray3);

        legs1 = new List<GameObject>(tableLegArray1);
        legs2 = new List<GameObject>(tableLegArray2);
        legs3 = new List<GameObject>(tableLegArray3);

        // Загрузить последние выбранные индексы
        int lastChairIndex = PlayerPrefs.GetInt(lastChairKey, 1);
        int lastTopIndex = PlayerPrefs.GetInt(lastTopKey, 1);
        int lastLegIndex = PlayerPrefs.GetInt(lastLegKey, 1);
        int lastChairColorIndex = PlayerPrefs.GetInt(lastChairColorKey, 1);
        int lastTableTopColorIndex = PlayerPrefs.GetInt(lastTableTopColorKey, 1);
        int lastTableLegColorIndex = PlayerPrefs.GetInt(lastTableLegColorKey, 1);

        // Применить сохраненные выборы
        UseChair(lastChairIndex);
        UseTableTop(lastTopIndex);
        UseTableLeg(lastLegIndex);

        // Переместим вызов UseColor после сохранения цвета
        UseColor(lastChairColorIndex, lastTableTopColorIndex, lastTableLegColorIndex);
    }


    // Сохранить последние выбранные индексы
    public void SaveLastChair(int chairIndex)
    {
        PlayerPrefs.SetInt(lastChairKey, chairIndex);
        PlayerPrefs.Save();
    }

    public void SaveLastTop(int topIndex)
    {
        PlayerPrefs.SetInt(lastTopKey, topIndex);
        PlayerPrefs.Save();
    }

    public void SaveLastLeg(int legIndex)
    {
        PlayerPrefs.SetInt(lastLegKey, legIndex);
        PlayerPrefs.Save();
    }

    private void UseChair(int chairIndex)
    {
        // Отключить все стулья
        foreach (GameObject chair in chairs1)
        {
            chair.SetActive(false);
        }
        foreach (GameObject chair in chairs2)
        {
            chair.SetActive(false);
        }
        foreach (GameObject chair in chairs3)
        {
            chair.SetActive(false);
        }

        // Включить стулья на основе индекса стула
        switch (chairIndex)
        {
            case 1:
                foreach (GameObject chair in chairs1)
                {
                    chair.SetActive(true); // Активировать стулья с тегом Chair1
                }
                break;
            case 2:
                foreach (GameObject chair in chairs2)
                {
                    chair.SetActive(true); // Активировать стулья с тегом Chair2
                }
                break;
            case 3:
                foreach (GameObject chair in chairs3)
                {
                    chair.SetActive(true); // Активировать стулья с тегом Chair3
                }
                break;
            // Добавить случаи для дополнительных типов стульев при необходимости
            default:
                Debug.LogError("Недопустимый индекс стула: " + chairIndex);
                break;
        }
    }

    private void UseTableTop(int topIndex)
    {
        // Отключить все столешницы
        foreach (GameObject top in tops1)
        {
            top.SetActive(false);
        }
        foreach (GameObject top in tops2)
        {
            top.SetActive(false);
        }
        foreach (GameObject top in tops3)
        {
            top.SetActive(false);
        }

        // Включить столешницы на основе индекса столешницы
        switch (topIndex)
        {
            case 1:
                foreach (GameObject top in tops1)
                {
                    top.SetActive(true); // Активировать столешницы с тегом Table-top1
                }
                break;
            case 2:
                foreach (GameObject top in tops2)
                {
                    top.SetActive(true); // Активировать столешницы с тегом Table-top2
                }
                break;
            case 3:
                foreach (GameObject top in tops3)
                {
                    top.SetActive(true); // Активировать столешницы с тегом Table-top3
                }
                break;
            // Добавить случаи для дополнительных типов столешниц при необходимости
            default:
                Debug.LogError("Недопустимый индекс столешницы: " + topIndex);
                break;
        }
    }

    private void UseTableLeg(int legIndex)
    {
        // Отключить все ножки столов
        foreach (GameObject leg in legs1)
        {
            leg.SetActive(false);
        }
        foreach (GameObject leg in legs2)
        {
            leg.SetActive(false);
        }
        foreach (GameObject leg in legs3)
        {
            leg.SetActive(false);
        }

        // Включить ножки столов на основе индекса ножки
        switch (legIndex)
        {
            case 1:
                foreach (GameObject leg in legs1)
                {
                    leg.SetActive(true); // Активировать ножки столов с тегом Table-leg1
                }
                break;
            case 2:
                foreach (GameObject leg in legs2)
                {
                    leg.SetActive(true); // Активировать ножки столов с тегом Table-leg2
                }
                break;
            case 3:
                foreach (GameObject leg in legs3)
                {
                    leg.SetActive(true); // Активировать ножки столов с тегом Table-leg3
                }
                break;
            // Добавить случаи для дополнительных типов ножек столов при необходимости
            default:
                Debug.LogError("Недопустимый индекс ножки стола: " + legIndex);
                break;
        }
    }

    private void UseColor(int chairColorIndex, int tableTopColorIndex, int tableLegColorIndex)
    {
        if (chairColors.ContainsKey(chairColorIndex) && chairColors.ContainsKey(tableTopColorIndex) && chairColors.ContainsKey(tableLegColorIndex))
        {
            SetChairColor(chairColorIndex);
            SetTableTopColor(tableTopColorIndex);
            SetTableLegColor(tableLegColorIndex);

            SaveColor(chairColorIndex, tableTopColorIndex, tableLegColorIndex);
        }
    }


    private void SaveColor(int chairColorIndex, int tableTopColorIndex, int tableLegColorIndex)
    {
        PlayerPrefs.SetInt(lastChairColorKey, chairColorIndex);
        PlayerPrefs.SetInt(lastTableTopColorKey, tableTopColorIndex);
        PlayerPrefs.SetInt(lastTableLegColorKey, tableLegColorIndex);
        PlayerPrefs.Save();
    }

    public void UseChair1()
    {
        UseChair(1);
    }

    public void UseChair2()
    {
        UseChair(2);
    }

    public void UseChair3()
    {
        UseChair(3);
    }

    public void UseTableTop1()
    {
        UseTableTop(1);
    }

    public void UseTableTop2()
    {
        UseTableTop(2);
    }

    public void UseTableTop3()
    {
        UseTableTop(3);
    }

    public void UseTableLeg1()
    {
        UseTableLeg(1);
    }

    public void UseTableLeg2()
    {
        UseTableLeg(2);
    }

    public void UseTableLeg3()
    {
        UseTableLeg(3);
    }

    public void OpenModMenu()
    {
        ModMenu.SetActive(true);
        Joystick.SetActive(false);
        HandButton.SetActive(false);
        ModMenuButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseModMenu()
    {
        ModMenu.SetActive(false);
        Joystick.SetActive(true);
        HandButton.SetActive(true);
        ModMenuButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void BackMainBuildMenu()
    {
        if (TablesMenu.activeInHierarchy || InteriersMenu.activeInHierarchy)
        {
            MainBuildMenu.SetActive(true);
            TablesMenu.SetActive(false);
            InteriersMenu.SetActive(false);
            PreviousMenuButton.SetActive(false);
        }
        if (ChairColorMenu.activeInHierarchy || TableTopColorMenu.activeInHierarchy || TableLegColorMenu.activeInHierarchy)
        {
            TablesMenu.SetActive(true);
            ChairColorMenu.SetActive(false);
            TableLegColorMenu.SetActive(false);
            TableTopColorMenu.SetActive(false);
        }
    }

    public void OpenTablesBuildMenu()
    {
        MainBuildMenu.SetActive(false);
        TablesMenu.SetActive(true);
        InteriersMenu.SetActive(false);
        PreviousMenuButton.SetActive(true);
    }

    public void OpenInterierBuildMenu()
    {
        MainBuildMenu.SetActive(false);
        TablesMenu.SetActive(false);
        InteriersMenu.SetActive(true);
        PreviousMenuButton.SetActive(true);
    }

    public void OpenChairColorSelect()
    {
        ChairColorMenu.SetActive(true);
        TablesMenu.SetActive(false);
    }

    public void OpenTableTopColorSelect()
    {
        TableTopColorMenu.SetActive(true);
        TablesMenu.SetActive(false);
    }

    public void OpenTableLegColorSelect()
    {
        TableLegColorMenu.SetActive(true);
        TablesMenu.SetActive(false);
    }

    public void UseChairColor1()
    {
        SetChairColor(1);
        SaveChairColor(1);
    }

    public void UseChairColor2()
    {
        SetChairColor(2);
        SaveChairColor(2);
    }

    public void UseChairColor3()
    {
        SetChairColor(3);
        SaveChairColor(3);
    }

    public void UseChairColor4()
    {
        SetChairColor(4);
        SaveChairColor(4);
    }

    public void UseChairColor5()
    {
        SetChairColor(5);
        SaveChairColor(5);
    }

    public void UseChairColor6()
    {
        SetChairColor(6);
        SaveChairColor(6);
    }

    public void UseChairColor7()
    {
        SetChairColor(7);
        SaveChairColor(7);
    }

    public void UseTableTopColor1()
    {
        SetTableTopColor(1);
        SaveTableTopColor(1);
    }

    public void UseTableTopColor2()
    {
        SetTableTopColor(2);
        SaveTableTopColor(2);
    }

    public void UseTableTopColor3()
    {
        SetTableTopColor(3);
        SaveTableTopColor(3);
    }

    public void UseTableTopColor4()
    {
        SetTableTopColor(4);
        SaveTableTopColor(4);
    }

    public void UseTableTopColor5()
    {
        SetTableTopColor(5);
        SaveTableTopColor(5);
    }

    public void UseTableTopColor6()
    {
        SetTableTopColor(6);
        SaveTableTopColor(6);
    }

    public void UseTableTopColor7()
    {
        SetTableTopColor(7);
        SaveTableTopColor(7);
    }

    public void UseTableLegColor1()
    {
        SetTableLegColor(1);
        SaveTableLegColor(1);
    }

    public void UseTableLegColor2()
    {
        SetTableLegColor(2);
        SaveTableLegColor(2);
    }

    public void UseTableLegColor3()
    {
        SetTableLegColor(3);
        SaveTableLegColor(3);
    }

    public void UseTableLegColor4()
    {
        SetTableLegColor(4);
        SaveTableLegColor(4);
    }

    public void UseTableLegColor5()
    {
        SetTableLegColor(5);
        SaveTableLegColor(5);
    }

    public void UseTableLegColor6()
    {
        SetTableLegColor(6);
        SaveTableLegColor(6);
    }

    public void UseTableLegColor7()
    {
        SetTableLegColor(7);
        SaveTableLegColor(7);
    }


    private void SaveChairColor(int chairColorIndex)
    {
        PlayerPrefs.SetInt(lastChairColorKey, chairColorIndex);
        PlayerPrefs.Save();
    }

    private void SaveTableTopColor(int tableTopColorIndex)
    {
        PlayerPrefs.SetInt(lastTableTopColorKey, tableTopColorIndex);
        PlayerPrefs.Save();
    }

    private void SaveTableLegColor(int tableLegColorIndex)
    {
        PlayerPrefs.SetInt(lastTableLegColorKey, tableLegColorIndex);
        PlayerPrefs.Save();
    }

    // Установка цвета для стула
    private void SetChairColor(int colorIndex)
    {
        if (chairColors.ContainsKey(colorIndex))
        {
            UnityEngine.Color color = chairColors[colorIndex];
            foreach (GameObject chair in chairs1)
            {
                MeshRenderer meshRenderer = chair.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            foreach (GameObject chair in chairs2)
            {
                MeshRenderer meshRenderer = chair.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            foreach (GameObject chair in chairs3)
            {
                MeshRenderer meshRenderer = chair.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            Debug.Log("Цвет стула установлен: " + color);
            SaveChairColor(colorIndex);
        }
        else
        {
            Debug.LogError("Недопустимый индекс цвета стула: " + colorIndex);
        }
    }

    // Установка цвета для столешницы
    private void SetTableTopColor(int colorIndex)
    {
        if (chairColors.ContainsKey(colorIndex))
        {
            UnityEngine.Color color = chairColors[colorIndex];
            foreach (GameObject top in tops1)
            {
                MeshRenderer meshRenderer = top.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            foreach (GameObject top in tops2)
            {
                MeshRenderer meshRenderer = top.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            foreach (GameObject top in tops3)
            {
                MeshRenderer meshRenderer = top.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            Debug.Log("Цвет столешницы установлен: " + color);
            SaveTableTopColor(colorIndex);
        }
        else
        {
            Debug.LogError("Недопустимый индекс цвета столешницы: " + colorIndex);
        }
    }

    // Установка цвета для ножки стола
    private void SetTableLegColor(int colorIndex)
    {
        if (chairColors.ContainsKey(colorIndex))
        {
            UnityEngine.Color color = chairColors[colorIndex];
            foreach (GameObject leg in legs1)
            {
                MeshRenderer meshRenderer = leg.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            foreach (GameObject leg in legs2)
            {
                MeshRenderer meshRenderer = leg.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            foreach (GameObject leg in legs3)
            {
                MeshRenderer meshRenderer = leg.transform.Find("default").GetComponent<MeshRenderer>();
                meshRenderer.material.color = color;
            }
            Debug.Log("Цвет ножки стола установлен: " + color);
            SaveTableLegColor(colorIndex);
        }
        else
        {
            Debug.LogError("Недопустимый индекс цвета ножки стола: " + colorIndex);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    public GameObject ModMenu, Joystick, HandButton, ModMenuButton, PreviousMenuButton;
    public GameObject OpenBuildTablesMenuButton, OpenBuildInterierMenuButton, MainBuildMenu, TablesMenu, InteriersMenu;

    private GameObject[] chairArray1, chairArray2, chairArray3;
    private GameObject[] tableTopArray1, tableTopArray2, tableTopArray3;
    private GameObject[] tableLegArray1, tableLegArray2, tableLegArray3;
    public GameObject Wall1, Wall2, Wall3, Floor1, Floor2, Floor3;

    public List<GameObject> chairs1, chairs2, chairs3;
    public List<GameObject> tops1, tops2, tops3;
    public List<GameObject> legs1, legs2, legs3;

    private string lastChairKey = "LastSelectedChair";
    private string lastTopKey = "LastSelectedTop";
    private string lastLegKey = "LastSelectedLeg";

    private string lastFloorKey = "LastSelectedFloor";
    private string lastWallKey = "LastSelectedWall";

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
        MainBuildMenu.SetActive(true);
        TablesMenu.SetActive(false);
        InteriersMenu.SetActive(false);
        PreviousMenuButton.SetActive(false);
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

    public void Start()
    {
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

        int lastChairIndex = PlayerPrefs.GetInt(lastChairKey, 1);
        int lastTopIndex = PlayerPrefs.GetInt(lastTopKey, 1);
        int lastLegIndex = PlayerPrefs.GetInt(lastLegKey, 1);

        int lastFloorIndex = PlayerPrefs.GetInt(lastFloorKey, 1);
        int lastWallIndex = PlayerPrefs.GetInt(lastWallKey, 1);

        UseChair(lastChairIndex);
        UseTable_top(lastTopIndex);
        UseTable_leg(lastLegIndex);

        UseFloor(lastFloorIndex);
        UseWall(lastWallIndex);
    }

    public void UseWall1()
    {
        Wall1.SetActive(true);
        Wall2.SetActive(false);
        Wall3.SetActive(false);
        PlayerPrefs.SetInt(lastWallKey, 1);
        PlayerPrefs.Save();
    }
    public void UseWall2()
    {
        Wall1.SetActive(false);
        Wall2.SetActive(true);
        Wall3.SetActive(false);
        PlayerPrefs.SetInt(lastWallKey, 2);
        PlayerPrefs.Save();
    }
    public void UseWall3()
    {
        Wall1.SetActive(false);
        Wall2.SetActive(false);
        Wall3.SetActive(true);
        PlayerPrefs.SetInt(lastWallKey, 3);
        PlayerPrefs.Save();
    }
    public void UseFloor1()
    {
        Floor1.SetActive(true);
        Floor2.SetActive(false);
        Floor3.SetActive(false);
        PlayerPrefs.SetInt(lastFloorKey, 1);
        PlayerPrefs.Save();
    }
    public void UseFloor2()
    {
        Floor1.SetActive(false);
        Floor2.SetActive(true);
        Floor3.SetActive(false);
        PlayerPrefs.SetInt(lastFloorKey, 2);
        PlayerPrefs.Save();
    }
    public void UseFloor3()
    {
        Floor1.SetActive(false);
        Floor2.SetActive(false);
        Floor3.SetActive(true);
        PlayerPrefs.SetInt(lastFloorKey, 3);
        PlayerPrefs.Save();
    }

    public void UseChair(int chairIndex)
    {
        foreach (List<GameObject> chairs in new List<GameObject>[] { chairs1, chairs2, chairs3 })
        {
            foreach (GameObject chair in chairs)
            {
                chair.SetActive(false);
            }
        }
        if (chairIndex == 1)
        {
            foreach (GameObject chair in chairs1)
            {
                chair.SetActive(true);
            }
        }
        else if (chairIndex == 2)
        {
            foreach (GameObject chair in chairs2)
            {
                chair.SetActive(true);
            }
        }
        else if (chairIndex == 3)
        {
            foreach (GameObject chair in chairs3)
            {
                chair.SetActive(true);
            }
        }
        SaveLastChair(chairIndex);
    }

    public void UseTable_top(int topIndex)
    {
        foreach (List<GameObject> tops in new List<GameObject>[] { tops1, tops2, tops3 })
        {
            foreach (GameObject top in tops)
            {
                top.SetActive(false);
            }
        }
        if (topIndex == 1)
        {
            foreach (GameObject top in tops1)
            {
                top.SetActive(true);
            }
        }
        else if (topIndex == 2)
        {
            foreach (GameObject top in tops2)
            {
                top.SetActive(true);
            }
        }
        else if (topIndex == 3)
        {
            foreach (GameObject top in tops3)
            {
                top.SetActive(true);
            }
        }
        SaveLastTop(topIndex);
    }

    public void UseTable_leg(int legIndex)
    {
        foreach (List<GameObject> legs in new List<GameObject>[] { legs1, legs2, legs3 })
        {
            foreach (GameObject leg in legs)
            {
                leg.SetActive(false);
            }
        }
        if (legIndex == 1)
        {
            foreach (GameObject leg in legs1)
            {
                leg.SetActive(true);
            }
        }
        else if (legIndex == 2)
        {
            foreach (GameObject leg in legs2)
            {
                leg.SetActive(true);
            }
        }
        else if (legIndex == 3)
        {
            foreach (GameObject leg in legs3)
            {
                leg.SetActive(true);
            }
        }
        SaveLastLeg(legIndex);
    }

    private void UseFloor(int floorIndex)
    {
        switch (floorIndex)
        {
            case 1:
                Floor1.SetActive(true);
                Floor2.SetActive(false);
                Floor3.SetActive(false);
                break;
            case 2:
                Floor1.SetActive(false);
                Floor2.SetActive(true);
                Floor3.SetActive(false);
                break;
            case 3:
                Floor1.SetActive(false);
                Floor2.SetActive(false);
                Floor3.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid floor index: " + floorIndex);
                break;
        }
    }

    private void UseWall(int wallIndex)
    {
        switch (wallIndex)
        {
            case 1:
                Wall1.SetActive(true);
                Wall2.SetActive(false);
                Wall3.SetActive(false);
                break;
            case 2:
                Wall1.SetActive(false);
                Wall2.SetActive(true);
                Wall3.SetActive(false);
                break;
            case 3:
                Wall1.SetActive(false);
                Wall2.SetActive(false);
                Wall3.SetActive(true);
                break;
            default:
                Debug.LogError("Invalid wall index: " + wallIndex);
                break;
        }
    }

    // Методы для сохранения выборов
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

    public void UseChair1()
    {
        foreach (GameObject chair in chairs1)
        {
            chair.SetActive(true);
        }
        foreach (GameObject chair in chairs2)
        {
            chair.SetActive(false);
        }
        foreach (GameObject chair in chairs3)
        {
            chair.SetActive(false);
        }
        SaveLastChair(1);
    }

    public void UseChair2()
    {
        foreach (GameObject chair in chairs1)
        {
            chair.SetActive(false);
        }
        foreach (GameObject chair in chairs2)
        {
            chair.SetActive(true);
        }
        foreach (GameObject chair in chairs3)
        {
            chair.SetActive(false);
        }
        SaveLastChair(2);
    }

    public void UseChair3()
    {
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
            chair.SetActive(true);
        }
        SaveLastChair(3);
    }

    public void UseTable_top1()
    {
        foreach (GameObject top in tops1)
        {
            top.SetActive(true);
        }
        foreach (GameObject top in tops2)
        {
            top.SetActive(false);
        }
        foreach (GameObject top in tops3)
        {
            top.SetActive(false);
        }
        SaveLastTop(1);
    }

    public void UseTable_top2()
    {
        foreach (GameObject top in tops1)
        {
            top.SetActive(false);
        }
        foreach (GameObject top in tops2)
        {
            top.SetActive(true);
        }
        foreach (GameObject top in tops3)
        {
            top.SetActive(false);
        }
        SaveLastTop(2);
    }

    public void UseTable_top3()
    {
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
            top.SetActive(true);
        }
        SaveLastTop(3);
    }

    public void UseTable_leg1()
    {
        foreach (GameObject leg in legs1)
        {
            leg.SetActive(true);
        }
        foreach (GameObject leg in legs2)
        {
            leg.SetActive(false);
        }
        foreach (GameObject leg in legs3)
        {
            leg.SetActive(false);
        }
        SaveLastLeg(1);
    }

    public void UseTable_leg2()
    {
        foreach (GameObject leg in legs1)
        {
            leg.SetActive(false);
        }
        foreach (GameObject leg in legs2)
        {
            leg.SetActive(true);
        }
        foreach (GameObject leg in legs3)
        {
            leg.SetActive(false);
        }
        SaveLastLeg(2);
    }

    public void UseTable_leg3()
    {
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
            leg.SetActive(true);
        }
        SaveLastLeg(3);
    }
}
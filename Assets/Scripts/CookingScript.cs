using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    private GameObject[] sitPlaces;
    public GameObject[] cookingImages;
    private bool[] hasOrder;
    private Color[] orderColors = { new Color(0f, 1f, 0f), new Color(1f, 1f, 0f), new Color(1f, 0f, 0f), new Color(1f, 0f, 1f), new Color(0f, 0f, 1f) };

    public GameObject[] imageButtons;
    public GameObject headImage;

    private void Start()
    {
        sitPlaces = GameObject.FindGameObjectsWithTag("SitPlace");
        hasOrder = new bool[sitPlaces.Length];
    }

    public void AddOrder()
    {
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < sitPlaces.Length; i++)
        {
            if (!hasOrder[i])
            {
                availableIndices.Add(i);
            }
        }

        if (availableIndices.Count == 0)
        {
            Debug.Log("Нет доступных мест для размещения заказа.");
            return;
        }

        int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];
        int randomOrderIndex = Random.Range(0, orderColors.Length);
        Color orderColor = orderColors[randomOrderIndex];

        sitPlaces[randomIndex].GetComponent<SpriteRenderer>().material.color = orderColor;
        hasOrder[randomIndex] = true;

        for (int i = 0; i < cookingImages.Length; i++)
        {
            if (!cookingImages[i].activeSelf)
            {
                cookingImages[i].SetActive(true);
                cookingImages[i].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = orderColor;

                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string triggerName = other.name;
        int zoneNumber;
        if (int.TryParse(triggerName, out zoneNumber) && zoneNumber >= 1 && zoneNumber <= 5)
        {
            if (zoneNumber < imageButtons.Length)
            {
                imageButtons[zoneNumber].SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        string triggerName = other.name;
        int zoneNumber;
        if (int.TryParse(triggerName, out zoneNumber) && zoneNumber >= 1 && zoneNumber <= 5)
        {
            if (zoneNumber < imageButtons.Length)
            {
                imageButtons[zoneNumber].SetActive(false);
            }
        }
        if (imageButtons.Length > 0)
        {
            imageButtons[0].SetActive(true);
        }
    }

    public void TakeCooking1()
    {
        if (headImage.activeSelf == false && cookingImages[0].activeSelf == true)
        {
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[0].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;
            cookingImages[0].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[0].SetActive(false);

            for (int i = 1; i < 6; i++)
            {
                imageButtons[i].SetActive(false);
            }
            imageButtons[0].SetActive(true);
        }
        else
        {
            Debug.Log("Руки заянты");
        }
    }

    public void TakeCooking2()
    {
        if (headImage.activeSelf == false && cookingImages[1].activeSelf == true)
        {
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[1].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;
            cookingImages[1].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[1].SetActive(false);

            for (int i = 1; i < 6; i++)
            {
                imageButtons[i].SetActive(false);
            }
            imageButtons[0].SetActive(true);
        }
        else
        {
            Debug.Log("Руки заянты");
        }
    }

    public void TakeCooking3()
    {
        if (headImage.activeSelf == false && cookingImages[2].activeSelf == true)
        {
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[2].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;
            cookingImages[2].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[2].SetActive(false);

            for (int i = 1; i < 6; i++)
            {
                imageButtons[i].SetActive(false);
            }
            imageButtons[0].SetActive(true);
        }
        else
        {
            Debug.Log("Руки заянты");
        }
    }

    public void TakeCooking4()
    {
        if (headImage.activeSelf == false && cookingImages[3].activeSelf == true)
        {
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[3].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;
            cookingImages[3].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[3].SetActive(false);

            for (int i = 1; i < 6; i++)
            {
                imageButtons[i].SetActive(false);
            }
            imageButtons[0].SetActive(true);
        }
        else
        {
            Debug.Log("Руки заянты");
        }
    }

    public void TakeCooking5()
    {
        if (headImage.activeSelf == false && cookingImages[4].activeSelf == true)
        {
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[4].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;
            cookingImages[4].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[4].SetActive(false);

            for (int i = 1; i < 6; i++)
            {
                imageButtons[i].SetActive(false);
            }
            imageButtons[0].SetActive(true);
        }
        else
        {
            Debug.Log("Руки заянты");
        }
    }
}

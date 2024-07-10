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

    private GameObject currentChair;

    private Queue<Color> orderQueue = new Queue<Color>();

    private void Start()
    {
        sitPlaces = GameObject.FindGameObjectsWithTag("SitPlace");
        hasOrder = new bool[sitPlaces.Length];

        for (int i = 0; i < sitPlaces.Length; i++)
        {
            sitPlaces[i].SetActive(false);
        }
    }

    public void AddOrder()
    {
        List<int> availableIndices = new List<int>();
        int randomIndex; // ���������� ���������� ���������� ����

        for (int i = 0; i < sitPlaces.Length; i++)
        {
            if (!hasOrder[i])
            {
                availableIndices.Add(i);
            }
        }

        bool hasAvailableCookingSpace = false;
        for (int i = 0; i < cookingImages.Length; i++)
        {
            if (!cookingImages[i].activeSelf)
            {
                hasAvailableCookingSpace = true;
                break;
            }
        }

        if (availableIndices.Count == 0 || !hasAvailableCookingSpace)
        {
            // ��������� ���� ������ � �������
            int randomOrderIndex = Random.Range(0, orderColors.Length);
            Color newOrderColor = orderColors[randomOrderIndex];
            orderQueue.Enqueue(newOrderColor);

            Debug.Log("����� �������� � �������.");

            // ���������� ������ ��������� ����� ��� ������� � ����� �������
            randomIndex = availableIndices[Random.Range(0, availableIndices.Count)]; // ���������� ������������ ����������
            sitPlaces[randomIndex].SetActive(true);
            sitPlaces[randomIndex].GetComponent<SpriteRenderer>().material.color = newOrderColor;

            // ������������� ����, ��� � ����� ����� ���� �����
            hasOrder[randomIndex] = true;

            return;
        }

        // ����� ��������� ����� ��� ������
        randomIndex = availableIndices[Random.Range(0, availableIndices.Count)]; // ���������� ������������ ����������
        Color orderColor = orderColors[Random.Range(0, orderColors.Length)];
        sitPlaces[randomIndex].SetActive(true);
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

    public void ServeOrder()
    {
        if (orderQueue.Count > 0)
        {
            for (int i = 0; i < cookingImages.Length; i++)
            {
                if (!cookingImages[i].activeSelf)
                {
                    // ��������� ���� ������ �� �������
                    Color orderColor = orderQueue.Dequeue();

                    // ��������� ���� � ����������� ������ �� ���� ������
                    cookingImages[i].SetActive(true);
                    cookingImages[i].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = orderColor;

                    // ��������� ���������� ������ ����� ������������ ������
                    return;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("chair"))
        {
            currentChair = other.transform.Find("Square").gameObject;

            // �������� ������ ��� �������� ������
            imageButtons[6].SetActive(true);

            // ��������� ��������� ������
            for (int i = 0; i < imageButtons.Length - 1; i++)
            {
                imageButtons[i].SetActive(false);
            }
        }
        else if (other.CompareTag("orderCounter"))
        {
            // ������������ ���� � ��������� ������ ������ �������
            // ��������, ���-�� ��������� � ���������� ������
            imageButtons[0].SetActive(false);
            imageButtons[6].SetActive(false);
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
    }

    private void OnTriggerExit(Collider other)
    {
        // ��������� ��������� ������
        for (int i = 0; i < imageButtons.Length; i++)
        {
            imageButtons[i].SetActive(false);
        }
        imageButtons[0].SetActive(true);
    }

    public void TakeCooking1()
    {
        TakeOrderFromCounter(0);
    }

    public void TakeCooking2()
    {
        TakeOrderFromCounter(1);
    }

    public void TakeCooking3()
    {
        TakeOrderFromCounter(2);
    }

    public void TakeCooking4()
    {
        TakeOrderFromCounter(3);
    }

    public void TakeCooking5()
    {
        TakeOrderFromCounter(4);
    }

    public void TakeOrderFromCounter(int cookingIndex)
    {
        // ���������, �������� �� ����� ������ � ������ �� ������
        if (!headImage.activeSelf && cookingImages[cookingIndex].activeSelf)
        {
            // �������� ����� � ����� ������ �� ������
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[cookingIndex].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;

            // ������� ����� ������ � ������ ��� �����
            cookingImages[cookingIndex].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[cookingIndex].SetActive(false);

            Debug.Log("����� ���� � ����� ������ � ������� �� ������.");

            // ���������, ���� �� ������ � �������
            if (orderQueue.Count > 0)
            {
                // ��������� ����� �� ������� � ���������� �� ������ ������
                Color orderColor = orderQueue.Dequeue();
                cookingImages[cookingIndex].SetActive(true);
                cookingImages[cookingIndex].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = orderColor;

                Debug.Log("����� �� ������� ����� �� ����� ������.");
            }
            else
            {
                Debug.Log("������� �����.");
            }
            if (!imageButtons[0].activeSelf)
            {
                imageButtons[0].SetActive(true);

                imageButtons[1].SetActive(false);
                imageButtons[2].SetActive(false);
                imageButtons[3].SetActive(false);
                imageButtons[4].SetActive(false);
                imageButtons[5].SetActive(false);

                imageButtons[6].SetActive(false);
            }
        }
        else
        {
            Debug.Log("���� ������ ��� ����� ������ ������.");
        }
    }

    public void ServeOrderFromHeadToChair()
    {
        if (currentChair != null)
        {
            // �������� ���� ������ �� ������
            Color headOrderColor = headImage.GetComponent<SpriteRenderer>().material.color;

            // �������� ���� ������ �� �����
            Color chairOrderColor = currentChair.GetComponent<SpriteRenderer>().material.color;

            // ���������� �����
            if (headOrderColor == chairOrderColor)
            {
                // ������ ���������, ������ �����
                Debug.Log("����� ����� �������.");
                headImage.GetComponent<SpriteRenderer>().material.color = Color.white;
                headImage.SetActive(false);
                currentChair.GetComponent<SpriteRenderer>().material.color = Color.white;
                currentChair.SetActive(false);
            }
            else
            {
                // ����� �� ���������, ������� ��������� �� ������
                Debug.Log("���� �� ���������.");
            }

            // ���������� ������ �����
            currentChair = null;
        }
        else
        {
            // ���� ���� �� ��� ����������, ������� ��������� �� ������
            Debug.Log("���� �� ������.");
        }
    }
}
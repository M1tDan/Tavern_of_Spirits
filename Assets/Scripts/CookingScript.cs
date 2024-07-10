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
        int randomIndex; // Перемещаем объявление переменной сюда

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
            // Добавляем цвет заказа в очередь
            int randomOrderIndex = Random.Range(0, orderColors.Length);
            Color newOrderColor = orderColors[randomOrderIndex];
            orderQueue.Enqueue(newOrderColor);

            Debug.Log("Заказ добавлен в очередь.");

            // Активируем первое доступное место для клиента с новым заказом
            randomIndex = availableIndices[Random.Range(0, availableIndices.Count)]; // Используем существующую переменную
            sitPlaces[randomIndex].SetActive(true);
            sitPlaces[randomIndex].GetComponent<SpriteRenderer>().material.color = newOrderColor;

            // Устанавливаем флаг, что у этого места есть заказ
            hasOrder[randomIndex] = true;

            return;
        }

        // Иначе добавляем заказ как обычно
        randomIndex = availableIndices[Random.Range(0, availableIndices.Count)]; // Используем существующую переменную
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
                    // Извлекаем цвет заказа из очереди
                    Color orderColor = orderQueue.Dequeue();

                    // Применяем цвет к изображению заказа на зоне выдачи
                    cookingImages[i].SetActive(true);
                    cookingImages[i].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = orderColor;

                    // Завершаем выполнение метода после обслуживания заказа
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

            // Включаем кнопку для передачи заказа
            imageButtons[6].SetActive(true);

            // Отключаем остальные кнопки
            for (int i = 0; i < imageButtons.Length - 1; i++)
            {
                imageButtons[i].SetActive(false);
            }
        }
        else if (other.CompareTag("orderCounter"))
        {
            // Обрабатываем вход в коллайдер стойки выдачи заказов
            // Например, что-то связанное с изменением кнопок
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
        // Отключаем остальные кнопки
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
        // Проверяем, доступно ли место выдачи и голова не занята
        if (!headImage.activeSelf && cookingImages[cookingIndex].activeSelf)
        {
            // Передаем заказ с места выдачи на голову
            headImage.SetActive(true);
            headImage.GetComponent<SpriteRenderer>().material.color = cookingImages[cookingIndex].transform.Find("Square").GetComponent<SpriteRenderer>().material.color;

            // Очищаем место выдачи и делаем его белым
            cookingImages[cookingIndex].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = Color.white;
            cookingImages[cookingIndex].SetActive(false);

            Debug.Log("Заказ взят с места выдачи и передан на голову.");

            // Проверяем, есть ли заказы в очереди
            if (orderQueue.Count > 0)
            {
                // Извлекаем заказ из очереди и выставляем на стойку выдачи
                Color orderColor = orderQueue.Dequeue();
                cookingImages[cookingIndex].SetActive(true);
                cookingImages[cookingIndex].transform.Find("Square").GetComponent<SpriteRenderer>().material.color = orderColor;

                Debug.Log("Заказ из очереди выдан на место выдачи.");
            }
            else
            {
                Debug.Log("Очередь пуста.");
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
            Debug.Log("Руки заняты или место выдачи занято.");
        }
    }

    public void ServeOrderFromHeadToChair()
    {
        if (currentChair != null)
        {
            // Получаем цвет заказа на голове
            Color headOrderColor = headImage.GetComponent<SpriteRenderer>().material.color;

            // Получаем цвет заказа на стуле
            Color chairOrderColor = currentChair.GetComponent<SpriteRenderer>().material.color;

            // Сравниваем цвета
            if (headOrderColor == chairOrderColor)
            {
                // Заказы совпадают, выдаем заказ
                Debug.Log("Заказ выдан клиенту.");
                headImage.GetComponent<SpriteRenderer>().material.color = Color.white;
                headImage.SetActive(false);
                currentChair.GetComponent<SpriteRenderer>().material.color = Color.white;
                currentChair.SetActive(false);
            }
            else
            {
                // Цвета не совпадают, выводим сообщение об ошибке
                Debug.Log("Цвет не совпадает.");
            }

            // Сбрасываем объект стула
            currentChair = null;
        }
        else
        {
            // Если стул не был установлен, выводим сообщение об ошибке
            Debug.Log("Стул не найден.");
        }
    }
}
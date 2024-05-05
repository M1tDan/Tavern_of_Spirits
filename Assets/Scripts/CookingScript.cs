using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    private GameObject[] sitPlacesArray;
    private List<GameObject> sitPlaces;
    private int randomPlaceCooking, quantityOfSitPlaces;

    private int cooking1, cooking2, cooking3, cooking4, cooking5;
    public GameObject cookingImage1, cookingImage2, cookingImage3, cookingImage4, cookingImage5;
    public Collider CookingColloder1, CookingColloder2, CookingColloder3, CookingColloder4, CookingColloder5;

    private Dictionary<int, UnityEngine.Color> Cookings = new Dictionary<int, UnityEngine.Color>
    {
        { 1, new UnityEngine.Color(0f, 1f, 0f) },
        { 2, new UnityEngine.Color(1f, 1f, 0f) },
        { 3, new UnityEngine.Color(1f, 0f, 0f) },
        { 4, new UnityEngine.Color(1f, 0f, 1f) },
        { 5, new UnityEngine.Color(0f, 0f, 1f) },
    };

    private void Start()
    {
        sitPlacesArray = GameObject.FindGameObjectsWithTag("SitPlace");
        sitPlaces = new List<GameObject>(sitPlacesArray);
        quantityOfSitPlaces = sitPlacesArray.Length;
        Debug.Log("Количество сидячих мест: " + quantityOfSitPlaces);
        foreach (GameObject sitPlace in sitPlaces)
        {
            randomPlaceCooking = Random.Range(1, 5);
            sitPlace.transform.GetComponent<SpriteRenderer>().material.color = Cookings[randomPlaceCooking];
        }

        ReCooking();
    }

    public void ReCooking()
    {
        ChoseCooking1();
        ChoseCooking2();
        ChoseCooking3();
        ChoseCooking4();
        ChoseCooking5();
        ChangeImage1();
        ChangeImage2();
        ChangeImage3();
        ChangeImage4();
        ChangeImage5();
    }

    private void ChoseCooking1()
    {
        cooking1 = Random.Range(1, 5);
    }
    private void ChoseCooking2()
    {
        cooking2 = Random.Range(1, 5);
    }
    private void ChoseCooking3()
    {
        cooking3 = Random.Range(1, 5);
    }
    private void ChoseCooking4()
    {
        cooking4 = Random.Range(1, 5);
    }
    private void ChoseCooking5()
    {
        cooking5 = Random.Range(1, 5);
    }

    private void ChangeImage1()
    {
        SpriteRenderer meshRenderer;
        switch (cooking1)
        {
            case 1:
                meshRenderer = cookingImage1.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[1];
                Debug.Log("1");
                break;
            case 2:
                meshRenderer = cookingImage1.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[2];
                Debug.Log("2");
                break;
            case 3:
                meshRenderer = cookingImage1.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[3];
                Debug.Log("3");
                break;
            case 4:
                meshRenderer = cookingImage1.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[4];
                Debug.Log("4");
                break;
            case 5:
                meshRenderer = cookingImage1.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[5];
                Debug.Log("5");
                break;
        }
    }
    private void ChangeImage2()
    {
        SpriteRenderer meshRenderer;
        switch (cooking2)
        {
            case 1:
                meshRenderer = cookingImage2.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[1];
                Debug.Log("1");
                break;
            case 2:
                meshRenderer = cookingImage2.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[2];
                Debug.Log("2");
                break;
            case 3:
                meshRenderer = cookingImage2.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[3];
                Debug.Log("3");
                break;
            case 4:
                meshRenderer = cookingImage2.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[4];
                Debug.Log("4");
                break;
            case 5:
                meshRenderer = cookingImage2.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[5];
                Debug.Log("5");
                break;
        }
    }
    private void ChangeImage3()
    {
        SpriteRenderer meshRenderer;
        switch (cooking3)
        {
            case 1:
                meshRenderer = cookingImage3.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[1];
                Debug.Log("1");
                break;
            case 2:
                meshRenderer = cookingImage3.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[2];
                Debug.Log("2");
                break;
            case 3:
                meshRenderer = cookingImage3.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[3];
                Debug.Log("3");
                break;
            case 4:
                meshRenderer = cookingImage3.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[4];
                Debug.Log("4");
                break;
            case 5:
                meshRenderer = cookingImage3.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[5];
                Debug.Log("5");
                break;
        }
    }
    private void ChangeImage4()
    {
        SpriteRenderer meshRenderer;
        switch (cooking4)
        {
            case 1:
                meshRenderer = cookingImage4.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[1];
                Debug.Log("1");
                break;
            case 2:
                meshRenderer = cookingImage4.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[2];
                Debug.Log("2");
                break;
            case 3:
                meshRenderer = cookingImage4.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[3];
                Debug.Log("3");
                break;
            case 4:
                meshRenderer = cookingImage4.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[4];
                Debug.Log("4");
                break;
            case 5:
                meshRenderer = cookingImage4.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[5];
                Debug.Log("5");
                break;
        }
    }
    private void ChangeImage5()
    {
        SpriteRenderer meshRenderer;
        switch (cooking5)
        {
            case 0:
                meshRenderer = cookingImage5.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[1];
                Debug.Log("1");
                break;
            case 1:
                meshRenderer = cookingImage5.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[2];
                Debug.Log("2");
                break;
            case 2:
                meshRenderer = cookingImage5.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[3];
                Debug.Log("3");
                break;
            case 3:
                meshRenderer = cookingImage5.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[4];
                Debug.Log("4");
                break;
            case 4:
                meshRenderer = cookingImage5.transform.GetComponent<SpriteRenderer>(); ;
                meshRenderer.material.color = Cookings[5];
                Debug.Log("5");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision Enter");
    }
}

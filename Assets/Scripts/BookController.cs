using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    public GameObject bookVisual;
    public float rotationSpeed = 10f;

    private bool collected = false;

    void Update()
    {
        if (!collected)
        {
            bookVisual.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void CollectBook()
    {
        collected = true;
        bookVisual.SetActive(false);
        Destroy(gameObject, 1f);
    }
}
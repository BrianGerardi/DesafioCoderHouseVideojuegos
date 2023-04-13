using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour
{
    public Transform[] bookSpawnLocations;
    public GameObject bookPrefab;

    void Start()
    {
        // Seleccionar aleatoriamente cinco posiciones de spawn que no se hayan utilizado antes
        List<Transform> selectedLocations = new List<Transform>();
        List<int> usedIndexes = new List<int>();
        for (int i = 0; i < 5; i++)
        {
            int index = GetRandomIndex(usedIndexes);
            usedIndexes.Add(index);
            selectedLocations.Add(bookSpawnLocations[index]);
        }

        // Instanciar libros en las posiciones seleccionadas
        foreach (Transform location in selectedLocations)
        {
            GameObject book = Instantiate(bookPrefab, location.position, location.rotation);
            book.GetComponent<BookController>().bookVisual.transform.SetParent(location);
        }
    }

    int GetRandomIndex(List<int> usedIndexes)
    {
        int index;
        do
        {
            index = Random.Range(0, bookSpawnLocations.Length);
        } while (usedIndexes.Contains(index));
        return index;
    }
}
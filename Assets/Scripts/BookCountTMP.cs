using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class BookCountTMP : MonoBehaviour
{
    public FPSController player;
    private TextMeshProUGUI text;

void Start()
{
    text = GetComponent<TextMeshProUGUI>();

    // Suscribir al evento BookCollected del objeto FPSController
    player.BookCollected.AddListener(OnBookCollected);
}

// Método que se llama cada vez que se recolecta un libro
void OnBookCollected(BookController book)
{
    // Actualizar el contador de pantalla
    text.text = "Books collected: " + player.bookCount;
     if (player.bookCount >= 5)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryScene");
    }
}}
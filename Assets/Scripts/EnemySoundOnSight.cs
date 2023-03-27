using UnityEngine;

public class EnemySoundOnSight : MonoBehaviour
{
    public AudioClip soundClip; // Sonido a reproducir
    private AudioSource audioSource;
    private EnemySelect enemy;

    private void Start()
    {
        enemy = GetComponent<EnemySelect>();
        enemy.EnemySawPlayerEvent += OnEnemySawPlayer;
        enemy.EnemyLostPlayerEvent += OnEnemyLostPlayer;

        audioSource = GetComponent<AudioSource>();

        // Asignar el clip de sonido desde el editor
        audioSource.clip = soundClip;
    }

    private void OnEnemySawPlayer()
    {
         Debug.LogFormat("Evento de audio del enemigo llamado desde {0}, recibido por {1}", enemy.name, gameObject.name);

        // Reproducir el sonido
        audioSource.Play();
    }

    private void OnEnemyLostPlayer()
    {
        // Detener la reproducción del sonido
        audioSource.Stop();
    }

    private void OnDestroy()
    {
        // Limpiar la suscripción al evento al destruir el objeto
        enemy.EnemySawPlayerEvent -= OnEnemySawPlayer;
        enemy.EnemyLostPlayerEvent -= OnEnemyLostPlayer;
    }
}
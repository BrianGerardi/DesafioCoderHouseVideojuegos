using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Enemigo", menuName = "Enemigo")]
public class EnemyStats : ScriptableObject {
    public string nombre;
    public float health;
    public float moveSpeed;
}
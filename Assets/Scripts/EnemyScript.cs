using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private string enemyName;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 scale;
    //[SerializeField] private Character1 character1;
    public Transform Player;
    [SerializeField] public float rotationSpeed;

    public float heal;
    void Start() 
    {
        /* character1.health =100; 
        enemyName = "pepito";
        transform.localScale = scale;
        character1.armor = 2;
        heal = 1;
        character1.damage = 3; */

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    /* public void Recivedamage ()
    {
       character1.health = character1.health - (character1.damage - character1.armor);
    }

    public void ReciveHeal ()
    {
        character1.health = character1.health + heal;
    } */
}

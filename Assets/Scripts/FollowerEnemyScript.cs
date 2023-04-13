using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerEnemyScript : MonoBehaviour

{
     public Transform Player;
    public float stopDistance = 2f;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {     
        transform.LookAt(Player.transform.position);
         Vector3 direction = (Player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, Player.position);

        if (distance > stopDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}

using UnityEngine;

public class EnemySelect : MonoBehaviour, IDamageable
{
    public EnemyStats enemyStats;
    public Transform Player;
    public float stopDistance = 1f;
    public Transform[] Waypoints;
    private Animator animator;

    private int currentWaypointIndex = 0;
    private bool isFollowingPlayer = false;

    public delegate void EnemySawPlayerEventHandler();
    public event EnemySawPlayerEventHandler EnemySawPlayerEvent;

    public delegate void EnemyLostPlayerEventHandler();
    public event EnemyLostPlayerEventHandler EnemyLostPlayerEvent;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isFollowingPlayer)
        {
            FollowPlayer();
        }
        else
        {
            PatrolWaypoints();
        }
    }

    void PatrolWaypoints()
    {
        Vector3 direction = (Waypoints[currentWaypointIndex].position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, Waypoints[currentWaypointIndex].position);

        animator.SetBool("Walking", true);
        if (distance > stopDistance)
        {
            transform.position += direction * enemyStats.moveSpeed * Time.deltaTime;
        }
        else
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % Waypoints.Length;
        }

        // check if player is visible
        if (CanSeePlayer())
        {
            isFollowingPlayer = true;
            // Activar el evento EnemySawPlayerEvent
            if (EnemySawPlayerEvent != null)
            {
                EnemySawPlayerEvent();
            }
        }

        transform.LookAt(Waypoints[currentWaypointIndex]);
    }

    void FollowPlayer()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, Player.position);

        animator.SetBool("Walking", true);
        if (distance > stopDistance)
        {
            transform.position += direction * enemyStats.moveSpeed * Time.deltaTime;
        }
        else
        {
            isFollowingPlayer = false;
        }

        // check if player is out of sight
        if (!CanSeePlayer())
        {
            isFollowingPlayer = false;
            // Desactivar el evento EnemySawPlayerEvent
            if (EnemyLostPlayerEvent != null)
            {
                EnemyLostPlayerEvent();
            }
        }

        transform.LookAt(Player);
    }

    bool CanSeePlayer()
    {
        Vector3 direction = Player.position - transform.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit))
        {
            if (hit.collider.gameObject == Player.gameObject)
            {
                return true;
            }
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        enemyStats.health -= damage;
        if (enemyStats.health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Play death animation and destroy enemy gameobject
        animator.SetBool("Walking", false);
        animator.SetBool("Dead", true);
        Destroy(gameObject, 2f);
    }
    void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        FPSController player = other.GetComponent<FPSController>();
        if (player != null)
        {
            player.OnEnemyContact.Invoke();
        }
    }
}
    
}
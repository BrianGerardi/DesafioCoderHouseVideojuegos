using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class FPSController : MonoBehaviour, IDamageable
{
public float speed = 10f;
public float mouseSensitivity = 100f;
public float clampAngle = 80f;
private float rotY = 0f;
private float rotX = 0f;
public float skinWidth = 0.1f;
public int bookCount = 0;
public int maxHealth = 100;
private int currentHealth;

public UnityEvent<Vector3> OnMove;
public UnityEvent<BookController> BookCollected;
public UnityEvent OnEnemyContact;




    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        currentHealth = maxHealth;
        OnEnemyContact.AddListener(HandleEnemyContact);

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);
        direction = Quaternion.Euler(0f, rotY, 0f) * direction;
        Vector3 velocity = direction * speed * Time.deltaTime;

 if (velocity.magnitude > 0)
{
    float distance = velocity.magnitude;
    RaycastHit hit;
    if (Physics.Raycast(transform.position, velocity, out hit, distance + skinWidth))
    {
        velocity = (hit.point - transform.position).normalized * distance;
    }

    transform.position = transform.position + velocity;

    // Llamar al evento de movimiento y pasar la dirección como parámetro
    OnMove.Invoke(direction);
}

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");

        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }

void OnTriggerEnter(Collider other)
{
    if (other.gameObject.CompareTag("Book"))
    {
        BookController book = other.GetComponent<BookController>();
        if (book != null)
        {
            book.CollectBook();
            bookCount++;

            // Llamar al evento de libro recolectado y pasar el objeto BookController como parámetro
            BookCollected.Invoke(book);

        }
    }
}


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage. Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Player died.");
     SceneManager.LoadScene("EscenaDeMuerte");
    }
    public bool IsMoving()
{
    return (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0);
}
void HandleEnemyContact()
{  
    Die();
}
}
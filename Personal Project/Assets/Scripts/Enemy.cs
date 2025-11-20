using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody enemyRb;
    private GameObject player;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");   // Finds the player object in the scene
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            // Direction from enemy to player
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;

            // Move toward the player
            enemyRb.MovePosition(transform.position + lookDirection * speed * Time.deltaTime);
        }
    }

    // OPTIONAL: Destroy the player on collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}

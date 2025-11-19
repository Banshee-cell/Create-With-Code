using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 5f; // you can adjust this
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        // Assign the player goal object (make sure it exists in the scene)
        playerGoal = GameObject.Find("Player Goal");
    }

    void Update()
    {
        if (playerGoal != null)
        {
            // Set enemy direction towards player goal and move there
            Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal" || other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }
    }
}

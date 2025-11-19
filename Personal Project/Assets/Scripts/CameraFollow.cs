using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;      // Reference to the player's transform
    public Vector3 offset;        // Position offset from the player
    public float smoothSpeed = 5f; // How quickly the camera follows

    void LateUpdate()
    {
        if (player == null)
            return;

        // Target position based on player position + offset
        Vector3 targetPosition = player.position + offset;

        // Smoothly move camera towards target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Optional: keep the same rotation (or you can make it look at the player)
        // transform.LookAt(player);
    }
}

using UnityEngine;

public class DestroyOutOfBoundsX : MonoBehaviour
{
    private float leftLimit = -30f;   // Destroy if too far left
    private float bottomLimit = -5f;  // Destroy if below the ground (Y-axis)

    void Update()
    {
        // Destroy objects that go too far left
        if (transform.position.x < leftLimit)
        {
            Destroy(gameObject);
        }
        // Destroy objects that fall below the map
        else if (transform.position.y < bottomLimit)
        {
            Destroy(gameObject);
        }
    }
}

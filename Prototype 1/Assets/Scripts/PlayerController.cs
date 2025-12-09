using UnityEngine;



public class PlayerController : MonoBehaviour
{
   [SerializeField] private float speed = 20.0f;
   [SerializeField] private float turnSpeed = 45.0f;
   [SerializeField] private float horizontalInput;
   [SerializeField] private float forwardInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        //Moves the car forward on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //Rotates the car based on Horizontal input
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}

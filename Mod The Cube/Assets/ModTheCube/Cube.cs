using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    void Start()
    {
        transform.position = new Vector3(5, 5, 5);
        transform.localScale = Vector3.one * 2.0f;
        
        Material material = Renderer.material;
        
        material.color = new Color(3, 2, 0.6f, 0.8f);
    }
    
    void Update()
    {
        transform.Rotate(20.0f * Time.deltaTime, 0.0f, 0.0f);
    }
}

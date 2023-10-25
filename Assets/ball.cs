using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ball : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private Material material;
    [SerializeField]

    int actualColor = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        material = rb.GetComponent<Renderer>().material;
    }
    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Sol")){
            ChangeColor();
        }
    }
    void ChangeColor(){
        material.color = new Color(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

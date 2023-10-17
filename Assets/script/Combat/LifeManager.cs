using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public Slider healthBar;
    public Vector3 offset = new Vector3(0, 2, 0); // Ajustez selon la position désirée

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        healthBar.transform.position = mainCamera.WorldToScreenPoint(transform.position + offset);
    }
    
    
     
}

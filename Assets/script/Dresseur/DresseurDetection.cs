using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresseurDetection : MonoBehaviour
{
    public Dresseurs dresseurData;
    public float detectionRange = 28f;
    private bool hasBattled = false;
    public LayerMask playerlayer;

    void Update()
    {
        Ray ray = new Ray( transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit,detectionRange, playerlayer)){
            if(hit.collider.CompareTag("Player")){
                Debug.Log("Le combat doit se lancer la");
                hit.collider.GetComponent<PlayerController>().detected = true;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * detectionRange);
    }
}

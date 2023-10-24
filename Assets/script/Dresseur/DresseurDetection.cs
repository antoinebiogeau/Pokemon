using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DresseurDetection : MonoBehaviour
{
    public Dresseurs dresseurData;
    public float detectionRange = 5f;
    private bool hasBattled = false;

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, detectionRange);
        if (hit.collider != null && hit.collider.CompareTag("Player") && !hasBattled)
        {
            // Déclenchez le combat ici
            Debug.Log("Combat déclenché avec " + dresseurData.dresseurName);
            hasBattled = true; // Pour éviter de déclencher plusieurs combats
        }
    }

    // Pour visualiser la portée de détection dans l'éditeur
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * detectionRange);
    }
}

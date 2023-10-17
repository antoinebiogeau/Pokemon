using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerBattle : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            StartBattle();
        }
    }

    void StartBattle()
    {
        SceneManager.LoadScene("Combat");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PokemonType { Feu, Eau, Plante }

[System.Serializable]
public class Attack
{
    public string attackName;
    public PokemonType attackType;
    public float damage;
}
public class Pokemon : MonoBehaviour
{
    
    public float health = 100;
    public PokemonType pokemonType;
    public Attack[] attacks = new Attack[4];
    public Slider healthBar;

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 20)
        {
            healthBar.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (health <= 50)
        {
            healthBar.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            healthBar.fillRect.GetComponent<Image>().color = Color.green;
        }
        if (health <= 0)
        {
            Debug.Log(gameObject.name + " est KO!");
            Destroy(gameObject);
        }
    }
}

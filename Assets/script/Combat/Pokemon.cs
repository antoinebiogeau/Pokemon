using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public PokemonData data; 
    public float currentHealth;
    public Slider healthBar;

    private void Start()
    {
        currentHealth = data.maxHP; 
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log(data.pokemonName + " est KO!");
            Destroy(gameObject);
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth / data.maxHP;

        if (currentHealth <= 20)
        {
            healthBar.fillRect.GetComponent<Image>().color = Color.red;
        }
        else if (currentHealth <= 50)
        {
            healthBar.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            healthBar.fillRect.GetComponent<Image>().color = Color.green;
        }
    }
}
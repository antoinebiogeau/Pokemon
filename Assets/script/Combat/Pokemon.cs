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

    public void TakeDamage(AttackData chosenAttack)
    {
        foreach (PokemonType type in chosenAttack.attackType.strongAgainst)
        {
            //si le type du pokemon est dans la liste de weakagainst
            if (type == data.pokemonType)
            {
                //on divise les dégats par 2
                currentHealth -= chosenAttack.damage / 2;
                Debug.Log("It's not very effective...");
            }
        }

        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log(data.pokemonName + " est KO!");
            Destroy(gameObject);
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth;

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
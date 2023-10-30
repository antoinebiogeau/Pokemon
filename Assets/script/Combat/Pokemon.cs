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
        if(chosenAttack.attackType.strongAgainst.ToString().Contains(data.pokemonType.typeName)){
            Debug.Log("C'est super efficace !");
            currentHealth -= chosenAttack.damage*2;
        }
        else if(chosenAttack.attackType.weakAgainst == data.pokemonType.strongAgainst){
            Debug.Log("Ce n'est pas très efficace...");
            currentHealth -= chosenAttack.damage/2;
        }
        else if(chosenAttack.attackType.weakAgainst == data.pokemonType.weakAgainst){
            Debug.Log("C'est ok !");
            currentHealth -= chosenAttack.damage;
        }
        else if(chosenAttack.attackType.strongAgainst == data.pokemonType.strongAgainst){
            Debug.Log("C'est ok !");
            currentHealth -= chosenAttack.damage;
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
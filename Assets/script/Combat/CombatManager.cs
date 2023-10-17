using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CombatManager : MonoBehaviour
{
public Pokemon playerPokemonPrefab; // Préfab du Pokémon du joueur pour l'instantiation
    public Pokemon enemyPokemonPrefab;  // Préfab du Pokémon ennemi pour l'instantiation

    private Pokemon playerPokemon;
    private Pokemon enemyPokemon;

    public GameObject bagUI;
    public string mainSceneName = "MainScene";

    public void StartBattle(PokemonData playerData, PokemonData wildData)
    {
        // Instancie les Pokémon pour le combat
        playerPokemon = Instantiate(playerPokemonPrefab);
        enemyPokemon = Instantiate(enemyPokemonPrefab);

        // Assigne les données aux Pokémon du combat
        playerPokemon.data = playerData;
        enemyPokemon.data = wildData;

        // Ici, tu peux ajouter d'autres initialisations, comme la mise à jour de l'UI, etc.
    }

    public void PlayerAttack(int attackIndex)
    {
        AttackData chosenAttack = playerPokemon.data.attacks[attackIndex];
        float damage = chosenAttack.damage;
        enemyPokemon.TakeDamage(damage);

        // Log pour l'attaque du joueur
        Debug.Log("Le joueur a utilisé " + chosenAttack.attackName + " et a infligé " + damage + " dégâts à l'ennemi.");
        Debug.Log("Fin de tour");
        EnemyTurn();
    }

    public void EnemyTurn()
    {
        int randomAttack = Random.Range(0, enemyPokemon.data.attacks.Count);
        AttackData chosenAttack = enemyPokemon.data.attacks[randomAttack];
        float damage = chosenAttack.damage;
        playerPokemon.TakeDamage(damage);

        // Log pour l'attaque de l'ennemi
        Debug.Log("L'ennemi a utilisé " + chosenAttack.attackName + " et a infligé " + damage + " dégâts au joueur.");
        Debug.Log("Fin du tour de l'ennemi.");
    }

    public void ToggleBagUI()
    {
        if (bagUI.activeSelf)
        {
            bagUI.SetActive(false);
        }
        else
        {
            bagUI.SetActive(true);
        }
    }

    public void FleeBattle()
    {
        Debug.Log("Le joueur a fui le combat.");
        SceneManager.LoadScene(mainSceneName);
    }
}

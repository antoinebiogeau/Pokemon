using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CombatManager : MonoBehaviour
{
    public Pokemon playerPokemonPrefab;
    public Pokemon enemyPokemonPrefab;

    private Pokemon playerPokemon;
    private Pokemon enemyPokemon;

    public GameObject bagUI;
    public string mainSceneName = "MainScene";
    public void Start()
    {
        if (BattleManager.Instance != null)
        {
            playerPokemon = Instantiate(playerPokemonPrefab, new Vector3(0, 0, -3), Quaternion.identity);
            playerPokemon.data = BattleManager.Instance.playerPokemonData;
            enemyPokemon = Instantiate(enemyPokemonPrefab, new Vector3(0, 0, 3), Quaternion.Euler(0, 180, 0)); 
            enemyPokemon.data = BattleManager.Instance.enemyPokemonData;
        }
    }
    public void StartBattle(PokemonData playerData, PokemonData wildData)
    {

        playerPokemon = Instantiate(playerPokemonPrefab);
        enemyPokemon = Instantiate(enemyPokemonPrefab);


        playerPokemon.data = playerData;
        enemyPokemon.data = wildData;


    }

    public void PlayerAttack(int attackIndex)
    {
        AttackData chosenAttack = playerPokemon.data.attacks[attackIndex];
        float damage = chosenAttack.damage;
        enemyPokemon.TakeDamage(damage);


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

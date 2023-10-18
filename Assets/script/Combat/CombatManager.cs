using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CombatManager : MonoBehaviour
{

    public Pokemon playerPokemon;
    public Pokemon enemyPokemon;
    public Slider healthBarEnemy;
    public Slider healthBarPlayer;
    public LifeManager PlayerLifeSet;
    public LifeManager EnemyLifeSet;
    public Camera mainCamera;
    public GameObject bagUI;
    public string mainSceneName = "main";

    public void Start()
    {
        if (BattleManager.Instance != null)
        {
            if (BattleManager.Instance.playerPokemonData == null)
            {
                Debug.LogError("playerPokemonData is null in BattleManager.");
            return;
            }
            // Récupération des prefabs à partir des ScriptableObjects
            GameObject playerPrefab = BattleManager.Instance.playerPokemonData.pokemonPrefab;
            GameObject enemyPrefab = BattleManager.Instance.enemyPokemonData.pokemonPrefab;
            playerPokemon = BattleManager.Instance.playerPokemonData.pokemonPrefab.GetComponent<Pokemon>();
            enemyPokemon = BattleManager.Instance.enemyPokemonData.pokemonPrefab.GetComponent<Pokemon>();
            EnemyLifeSet = BattleManager.Instance.enemyPokemonData.pokemonPrefab.GetComponent<LifeManager>();
            EnemyLifeSet.healthBar = healthBarEnemy;
            EnemyLifeSet.mainCamera = mainCamera;
            PlayerLifeSet = BattleManager.Instance.playerPokemonData.pokemonPrefab.GetComponent<LifeManager>();
            PlayerLifeSet.healthBar =  healthBarPlayer;
            PlayerLifeSet.mainCamera = mainCamera;


            if (enemyPrefab != null)
            {
                enemyPokemon = Instantiate(enemyPrefab, new Vector3(0, 0, 3), Quaternion.Euler(0, 180, 0)).GetComponent<Pokemon>();
                enemyPokemon.data = BattleManager.Instance.enemyPokemonData;
                enemyPokemon.healthBar = healthBarEnemy;
                Debug.Log("Enemy Pokemon instantiated at " + enemyPokemon.transform.position);
            }
            else
            {
                Debug.LogError("Enemy Pokemon prefab is null.");
            }
            if (playerPrefab != null)
            {
                playerPokemon = Instantiate(playerPrefab, new Vector3(0, 0, -3), Quaternion.identity).GetComponent<Pokemon>();
                playerPokemon.data = BattleManager.Instance.playerPokemonData;
                playerPokemon.healthBar = healthBarPlayer;
                Debug.Log("Player Pokemon instantiated at " + playerPokemon.transform.position);
            }
            else
            {
                Debug.LogError("Player Pokemon prefab is null.");
            }

            

        }
        else
        {
            Debug.LogError("CombatManager: BattleManager.Instance is null.");
        }
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
        bagUI.SetActive(!bagUI.activeSelf);
    }

    public void FleeBattle()
    {
        Debug.Log("Le joueur a fui le combat.");
        SceneManager.LoadScene(mainSceneName);
    }
}

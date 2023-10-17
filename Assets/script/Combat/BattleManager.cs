using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance;

    public PokemonData playerPokemonData;
    public PokemonData enemyPokemonData;

    private void Awake()
    {
        // Singleton pattern pour s'assurer qu'il n'y a qu'une seule instance de BattleManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartBattle(PokemonData playerData, PokemonData wildData)
    {
        playerPokemonData = playerData;
        enemyPokemonData = wildData;
        playerPokemonData = playerData;
        enemyPokemonData = wildData;

        Debug.Log("Setting playerPokemonData to: " + (playerPokemonData == null ? "NULL" : playerPokemonData.name));
        // Logs pour vérifier que les données sont correctement définies
        Debug.Log("BattleManager: Player Pokemon set to: " + playerPokemonData.name);
        Debug.Log("BattleManager: Enemy Pokemon set to: " + enemyPokemonData.name);

        // Change la scène vers la scène de combat
        SceneManager.LoadScene("Combat");
    }
}

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

        // Change la scène vers la scène de combat
        SceneManager.LoadScene("BattleScene"); // Remplace "BattleScene" par le nom de ta scène de combat
    }
}

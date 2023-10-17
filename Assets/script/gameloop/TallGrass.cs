using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallGrass : MonoBehaviour
{
    public List<PokemonData> wildPokemons;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartBattle(other.GetComponent<PlayerController>());
        }
    }

    void StartBattle(PlayerController player)
    {
        PokemonData wildPokemon = wildPokemons[Random.Range(0, wildPokemons.Count)];
        PokemonData playerPokemon = player.playerPokemons[0];

        BattleManager.Instance.StartBattle(playerPokemon, wildPokemon);
    }
}

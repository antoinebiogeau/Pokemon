using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Pokémon Game/Dresseur")]
public class Dresseurs : ScriptableObject
{
    public string dresseurName;
    public Sprite sprite;
    public List<DresseurPokemon> pokemons;

    [System.Serializable]
    public class DresseurPokemon
    {
        public PokemonData pokemon;
        public int level;
        public List<AttackData> attaques;
    }
}

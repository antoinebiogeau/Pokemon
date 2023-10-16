// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public enum PokemonType { fire, water, plant };
//
// public class ttt : MonoBehaviour
// {
//     float _Playerhealth = 100f;
//     string _Playertype = "fire";
//     public PokemonType _pokemontype = PokemonType.fire;
//
//     // Dictionnaire de dictionnaires pour stocker les coefficients de dommages
//     private Dictionary<PokemonType, Dictionary<PokemonType, float>> damageCoefficients = new Dictionary<PokemonType, Dictionary<PokemonType, float>>()
//     {
//         { PokemonType.water, new Dictionary<PokemonType, float> { { PokemonType.plant, 2f }, { PokemonType.fire, 0.5f } } },
//         { PokemonType.fire, new Dictionary<PokemonType, float> { { PokemonType.water, 2f }, { PokemonType.plant, 0.5f } } },
//         { PokemonType.plant, new Dictionary<PokemonType, float> { { PokemonType.fire, 2f }, { PokemonType.water, 0.5f } } }
//     };
//
//     // Fonction pour appliquer des dégâts
//     void TakeDamage(float DamageAmount, PokemonType attacktype)
//     {
//         if (damageCoefficients.ContainsKey(attacktype) && damageCoefficients[attacktype].ContainsKey(_pokemontype))
//         {
//             float damageCoefficient = damageCoefficients[attacktype][_pokemontype];
//             DamageAmount *= damageCoefficient;
//         }
//
//         // Appliquez les dégâts au joueur
//         _Playerhealth -= DamageAmount;
//         Debug.Log("Player took " + DamageAmount + " damage. New health: " + _Playerhealth);
//     }
//
//     void Die()
//     {
//         Destroy(gameObject);
//     }
//
//     // Détection de collision lorsque le cube entre dans un trigger
//     void OnTriggerEnter(Collider other)
//     {
//         ttt otherCubeScript = other.GetComponent<ttt>();
//         if (otherCubeScript != null && otherCubeScript._Playerhealth > 0f)
//         {
//             TakeDamage(10f, otherCubeScript._pokemontype);
//         }
//         else if (otherCubeScript != null && otherCubeScript._Playerhealth <= 0f)
//         {
//             Debug.Log("Player has no health left. Destroying the GameObject.");
//             Die();
//         }
//     }
// }

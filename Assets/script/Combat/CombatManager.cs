using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CombatManager : MonoBehaviour
{
    public Pokemon playerPokemon;
    public Pokemon enemyPokemon;
    public GameObject bagUI;
    public string mainSceneName = "MainScene";

    public void PlayerAttack(int attackIndex)
    {
        Attack chosenAttack = playerPokemon.attacks[attackIndex];
        float damage = chosenAttack.damage;
        enemyPokemon.TakeDamage(damage);

        // Log pour l'attaque du joueur
        Debug.Log("Le joueur a utilisé " + chosenAttack.attackName + " et a infligé " + damage + " dégâts à l'ennemi.");
        Debug.Log("Fin de tour");
        EnemyTurn();

    }

    public void EnemyTurn()
    {
        int randomAttack = Random.Range(0, 4);
        Attack chosenAttack = enemyPokemon.attacks[randomAttack];
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    [SerializeField] int scoreValue;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject lifePrefab;
    [SerializeField] GameObject healthPrefab;
    private const int life_Change = 1;
    private const int health_Change = 10;
    private const int coin_Change = 500;
    public void Kill()
    {
        UIManager.UpdateScore(scoreValue);
        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
        int ran = Random.Range(0,1000);
        if (ran<=life_Change)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if (ran <= health_Change)
        {
            Instantiate(lifePrefab, transform.position, Quaternion.identity);
        }
        else if(ran <= coin_Change)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        if (AlienMaster.allAliens.Count == 0)
        {
            GameManager.SpawnNewWave();
        }
        gameObject.SetActive(false);
    }
}

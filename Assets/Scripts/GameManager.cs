using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] allAlienSets;
    GameObject currentSet;
    Vector2 spawnPos = new Vector2(0, 10);
  public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnNewWave();
    }
    private IEnumerator SpawnWave()
    {
        if (currentSet!=null)
        {
            Destroy(currentSet);
        }
        yield return new WaitForSeconds(3);
        currentSet = Instantiate(allAlienSets[Random.Range(0,allAlienSets.Length)],spawnPos,Quaternion.identity);
        UIManager.UpdateWave();
    }
    public static void SpawnNewWave()
    {
        instance.StartCoroutine(instance.SpawnWave());
    }
}

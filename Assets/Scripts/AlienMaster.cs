using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlienMaster : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] ObjectPool objectPool = null;
    Vector3 hMoveDistance = new Vector3(0.05f, 0, 0);
    Vector3 vMoveDistance = new Vector3(0, 0.15f, 0);
    const float max_Left = -3f;
    const float max_right = 3f;
    public static List<GameObject> allAliens = new List<GameObject>();
    bool movingRight;
    float moveTimer = 0.01f;
    float moveTime = 0.005f;
    const float maxMoveSpeed = 0.02f;
    float shootTimer = 3f;
    const float ShootTime = 3f;
    [SerializeField] GameObject motherShipPrefabs;
    Vector3 motherShipSpawnPos = new Vector3(3.72f, 3.45f, 0);
    float motherShipTimer = 1f;
    const float motherShipMax = 15f;
    const float motherShipMin = 1f;
    const float start_Y = 0f;
    const float max_Move_Speed = 0.02f;
    bool entering = true;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (entering)
        {
            transform.Translate(Vector2.down * Time.deltaTime * 10);
            if (transform.position.y < start_Y)
            {
                entering = false;

            }
        }
        else
        {
            if (moveTimer <= 0)
            {
                MoveEnemies();
            }
            if (shootTimer <= 0)
            {
                Shoot();
            }
            if (motherShipTimer <= 0)
            {
                SpawnMoherShip();
            }
            {

            }
            moveTimer -= Time.deltaTime;
            shootTimer -= Time.deltaTime;
            motherShipTimer -= Time.deltaTime;
        }

    }
    void SpawnMoherShip()
    {
        Instantiate(motherShipPrefabs, motherShipSpawnPos, Quaternion.identity);
        motherShipTimer = UnityEngine.Random.Range(motherShipMin, motherShipMax);

    }
    private void Shoot()
    {
        Vector2 pos = allAliens[UnityEngine.Random.Range(0, allAliens.Count)].transform.position;
        //Instantiate(bulletPrefabs, pos, Quaternion.identity);
        GameObject obj = objectPool.GetPool();
        obj.transform.position = pos;
        shootTimer = ShootTime;
    }

    void MoveEnemies()
    {
        int hitMax = 0;
        if (allAliens.Count > 0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDistance;
                }
                else
                {
                    allAliens[i].transform.position -= hMoveDistance;
                }
                if (allAliens[i].transform.position.x > max_right || allAliens[i].transform.position.x < max_Left)
                {
                    hitMax++;
                }
            }
            if (hitMax > 0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                {
                    allAliens[i].transform.position -= vMoveDistance;
                }
                movingRight = !movingRight;
            }
            moveTimer = GetMoveSpeed();

        }
    }
    float GetMoveSpeed()
    {
        float f = allAliens.Count * moveTime;
        if (f > maxMoveSpeed)
        {
            return maxMoveSpeed;
        }
        else
        {
            return f;
        }
    }
}

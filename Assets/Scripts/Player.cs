using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    //[SerializeField] GameObject bullets;
    //[SerializeField]float speed = 3f;
    [SerializeField] private ObjectPool objectPool;
    private const float maxX = 2.0f;
    private const float minX = -2.0f;
    private bool isShooting;//Default hali false dýr
    //private float coolDown = 0.5f;
    private Transform parent;
    public ShipStats shipStats;
    private Vector2 offScreenPos = new Vector2(0, -20f);
    private Vector2 startScreenPos = new Vector2(0, -4f);
    private bool isRespawn = false;
    private float dirx;
    // Start is called before the first frame update
    void Start()
    {

        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currentLifes = shipStats.maxLifes;
        transform.position = startScreenPos;
        //Debug.Log(shipStats.curentHealth);
        //Debug.Log(shipStats.currentLifes);
        UIManager.UpdateHealthBar(shipStats.currentHealth);
        UIManager.UpdateLives(shipStats.currentLifes);
        //parent = GameObject.FindWithTag("Bullets").GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKey(KeyCode.A) && transform.position.x > minX)
        {
            transform.Translate(Vector2.left * shipStats.shipSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * shipStats.shipSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.Space) && !isShooting)
        {
            StartCoroutine("Shot");
        }
        if (isRespawn)
        {
            transform.Translate(Vector2.up * Time.deltaTime * 20);
            if (transform.position.y >= -4)
            {
                isRespawn = false;
            }

        }

#endif
        dirx = Input.acceleration.x;
        //Debug.Log(dirx);
        if (dirx <= -0.1f && transform.position.x > minX)
        {
            transform.Translate(Vector2.left * shipStats.shipSpeed * Time.deltaTime);
        }
        else if (dirx >= 0.1f && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right * shipStats.shipSpeed * Time.deltaTime);

        }

    }
    public void ShootButton()
    {
        if (!isShooting)
        {
            StartCoroutine(Shoot());
        }
    }
    private IEnumerator Shoot()
    {
        isShooting = true;

        NewBullet();
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }
    void NewBullet()
    {
        //GameObject bullet = Instantiate(bulletPrefabs, transform.position, Quaternion.identity);
        //bullet.transform.parent = parent;
        GameObject obj = objectPool.GetPool();
        obj.transform.position = gameObject.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("Player Hit!..");
            collision.gameObject.SetActive(false);
            TakeDamage();
        }
    }
    private IEnumerator Respwan()
    {
        transform.position = offScreenPos;
        isRespawn = true;
        //gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        shipStats.currentHealth = shipStats.maxHealth;
        //gameObject.SetActive(true);
        UIManager.UpdateHealthBar(shipStats.currentHealth);
        transform.position = startScreenPos;
    }
    public void TakeDamage()
    {
        shipStats.currentHealth--;
        //Debug.Log(shipStats.curentHealth);
        UIManager.UpdateHealthBar(shipStats.currentHealth);
        if (shipStats.currentHealth <= 0)
        {
            shipStats.currentLifes--;
            UIManager.UpdateLives(shipStats.currentLifes);
            if (shipStats.currentLifes <= 0)
            {

            }
            else
            {
                StartCoroutine(Respwan());
            }
        }

    }
    public void AddHealth()
    {
        if (shipStats.currentHealth == shipStats.maxHealth)
        {

            UIManager.UpdateScore(250);
        }
        else
        {
            shipStats.currentHealth++;
            UIManager.UpdateHealthBar(shipStats.currentHealth);
        }
    }
    public void AddLife()
    {
        if (shipStats.currentLifes == shipStats.maxLifes)
        {

            UIManager.UpdateScore(500);
        }
        else
        {
            shipStats.currentLifes++;
            UIManager.UpdateLives(shipStats.currentLifes);
        }
    }
    //private void ChangeLifeOrHealth(ShipStats stats,int score)
    //{

    //    if (stats.currentLifes == stats.maxLifes)
    //    {

    //        UIManager.UpdateScore(score);
    //    }
    //    else
    //    {
    //        stats.currentLifes++;
    //        UIManager.UpdateLives(stats.currentLifes);
    //    }
    //}

}

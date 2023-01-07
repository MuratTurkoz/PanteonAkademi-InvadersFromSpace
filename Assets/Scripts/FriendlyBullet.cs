using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 5f;
    [SerializeField] float maxY = 6f;
    private void Update()
    {
        
        MoveBullet();
    }
    void MoveBullet()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Alien"))
        {
            //Destroy(gameObject);
            collision.gameObject.GetComponent<Alien>().Kill();
            gameObject.SetActive(false);

        }
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            //Destroy(collision.gameObject);
            //Destroy(gameObject);
        }
    }
    void BulletDestory()
    {
        Destroy(gameObject);
    }
}

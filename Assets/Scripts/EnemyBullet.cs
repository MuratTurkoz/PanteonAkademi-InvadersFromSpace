using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float maxY = 6f;
    private void Update()
    {

        MoveBullet();
    }
    void MoveBullet()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
    void BulletDestory()
    {
        Destroy(gameObject);
    }
}

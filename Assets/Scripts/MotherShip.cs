using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int scoreValue;
     float speed = 5;
    const float maxLeft = -5f;
    private void Update()
    {
        transform.Translate(Vector2.left*Time.deltaTime*speed);
        if (transform.position.x<=maxLeft)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FriendlyBullet"))
        {
            UIManager.UpdateScore(scoreValue);
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}

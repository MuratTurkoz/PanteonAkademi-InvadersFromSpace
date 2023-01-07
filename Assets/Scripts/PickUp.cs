using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour, IPickUp
{
    public float fallSpeed;
    //public Player player;
    // Start is called before the first frame update

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PickMeUp();
        }
    }

    public void DestoryPickUp()
    {
        throw new NotImplementedException();
    }

    public abstract void PickMeUp();

}

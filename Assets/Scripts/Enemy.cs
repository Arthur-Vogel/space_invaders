using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public delegate void EnemyDied(int points);
    public static event EnemyDied OnEnemyDied;
    private int _movement = 0;
    public int max_right = 5;
    public int max_left = -5;
    public float speed = 2f;
    public float downSpeed = 0.75f;
    public int points = 300;
    public float time=10;

    private float decr;
    /*public int type_of_ennemy;
    Enemy(int typeOfEnnemy)
    {
      type_of_ennemy = typeOfEnnemy;
    }*/
    private void Update()
    {
        
      if(_movement == 1)
      {
        transform.position += Vector3.left * (Time.deltaTime * speed);
        if(decr <= 0)
        {
          _movement = 0;
          transform.position += Vector3.down *downSpeed;
          decr = time;
        }
        
      }
      if(_movement == 0)
      {
        transform.position += Vector3.right * (Time.deltaTime * speed);
        if(decr <= 0)
        {
          _movement = 1;
          transform.position += Vector3.down * downSpeed;
          decr = time;
        }
      }
      decr-= Time.deltaTime;
    }

    private void Start()
    {
      decr = time;
      
    }

    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      Debug.Log("Ouch!");
      Destroy(collision.gameObject);
      if (OnEnemyDied != null) OnEnemyDied.Invoke( points);
      Destroy(gameObject);
    }
}

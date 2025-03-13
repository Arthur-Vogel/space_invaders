using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
    public int intensity_of_shot = 100000;
    public GameObject bullet;
    private int random;

    private float decr;
    /*public int type_of_ennemy;
    Enemy(int typeOfEnnemy)
    {
      type_of_ennemy = typeOfEnnemy;
    }*/
    private void Update()
    {
       random = UnityEngine.Random.Range(0, intensity_of_shot);
       
      if(random == 1)
      { 
        GameObject shot = Instantiate(bullet, transform.position, Quaternion.identity);
        Destroy(shot, 6f);
      }
        
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
      if (collision.gameObject.CompareTag("playerBullet"))
      {
        Debug.Log("Ouch!");
        Destroy(collision.gameObject);
        if (OnEnemyDied != null) OnEnemyDied.Invoke(points);
        Destroy(gameObject);
      }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;
    // Update is called once per frame
    private void Start()
    {
      Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
    }
    void OnDestroy()
    {
      Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }
    void EnemyOnOnEnemyDied(int points)
    {
      Debug.Log("Yay! I got points :" + points);
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        //Destroy(shot, 3f);

      }
    }
}

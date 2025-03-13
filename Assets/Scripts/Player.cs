using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;
  
  public float speed = 5f;
  private Rigidbody2D rb;
  private float moveInput;
  private int score = 0;
  Animator playerAnimator;
  public Text scoreText;
  

  private static readonly int Property = Animator.StringToHash("Shoot trigger");

  // Update is called once per frame
    private void Start()
    {
      Enemy.OnEnemyDied += EnemyOnOnEnemyDied;
      playerAnimator = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      scoreText.text = score.ToString();
    }
    void OnDestroy()
    {
      Enemy.OnEnemyDied -= EnemyOnOnEnemyDied;
    }
    void EnemyOnOnEnemyDied(int points)
    {
      score += points;
      scoreText.text = score.ToString();
    }
    [Obsolete("Obsolete")]
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        playerAnimator.SetTrigger(Property);
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 6f);

      }
      moveInput = Input.GetAxisRaw("Horizontal");
      rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
      
    }
}

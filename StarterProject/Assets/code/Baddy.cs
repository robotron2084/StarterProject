using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Baddy : MonoBehaviour
{

  public GameStates state;
  public Rigidbody rigid;
  public float speed = 4.0f;

  public int hp = 3;

  void Awake()
  {
    rigid = GetComponent<Rigidbody>();
  }

  void Start()
  {
    rigid.AddForce(transform.forward * speed);
    state = GameStates.Alive;
  }

  void OnCollisionEnter(Collision c)
  {
    if(state == GameStates.Dead)
    {
      return;
    }
    Bullet b = c.gameObject.GetComponent<Bullet>();
    if(b != null)
    {
      b.OnHit();
      hp --;
      if(hp == 0)
      {
        Kill();
      }
    }
  }

  void Kill()
  {
    state = GameStates.Dead;
    //TODO: FX
    rigid.useGravity = true;
    rigid.velocity = Vector3.zero;
    Destroy(gameObject, 5.0f);
  }
}

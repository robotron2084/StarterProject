using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class Bullet : MonoBehaviour
{
  public float bulletLifetime;

  public Rigidbody rigid;

  IEnumerator Start()
  {
    yield return new WaitForSeconds(bulletLifetime);
    Destroy(gameObject);
  }

  public void OnHit()
  {
    Destroy(gameObject);
  }
}

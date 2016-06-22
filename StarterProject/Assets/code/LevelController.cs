using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class LevelController : MonoBehaviour
{

  // public SpawnPoint[] spawnPoints;

  public Player player;

  public Bullet bulletPrefab;

  [System.NonSerialized]
  public List<Baddy> baddies = new List<Baddy>();

  // When we are firing, this will not be null.
  IEnumerator fireRoutine;


  public float fireRate = 0.1f;
  public float fireForce = 10.0f;

  void Update()
  {
    if(Input.GetMouseButtonDown(0))
    {
      if(fireRoutine == null)
      {
        fireRoutine = shootThings();
        StartCoroutine(fireRoutine);
      }
    }
    if(Input.GetMouseButtonUp(0))
    {
      if(fireRoutine != null)
      {
        StopCoroutine(fireRoutine);
        fireRoutine = null;
      }
    }
  }

  IEnumerator shootThings()
  {
    while(true)
    {
      fire();
      yield return new WaitForSeconds(fireRate);
    }
  }

  void fire()
  {
    Bullet bullet = Instantiate(bulletPrefab);
    bullet.transform.position = player.transform.position;
    bullet.transform.rotation = player.transform.rotation;
    bullet.rigid.AddForce(bullet.transform.forward * fireForce);
  }


}

using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;

public class SpawnPoint : MonoBehaviour
{
  public BaddyWave[] waves;
  int waveIndex = 0;
  BaddyWave currentWave;
  int wavesMade = 0;

  IEnumerator spawnRoutine;

  [System.NonSerialized]
  public bool wavesComplete = false;

  void Start()
  {
    spawnRoutine = spawnThings();
    StartCoroutine(spawnRoutine);
  }

  IEnumerator spawnThings()
  {
    currentWave = waves[waveIndex];
    wavesMade = 0;
    while(true)
    {
      foreach(BaddyWaveItem item in currentWave.items)
      {
        spawn(item);
        yield return new WaitForSeconds(item.spawnTime);
      }
      wavesMade++;
      if(wavesMade >= currentWave.repeatAmount)
      {
        //we're done! make a new wave.
        waveIndex++;
        if(waveIndex >= waves.Length)
        {
          //We are done!
          wavesComplete = true;
          yield break;
        }else{
          //keep making waves...
          currentWave = waves[waveIndex];
          wavesMade = 0; // reset.
        }
      }else{
        //Keep going.
      }
    }
  }

  void spawn(BaddyWaveItem item)
  {
    Baddy baddy = Instantiate(item.baddyPrefab);
    baddy.transform.position = transform.position + item.posDelta;
    baddy.transform.rotation = transform.rotation;
    baddy.speed += item.speedModifier;
    baddy.Init();
  }

}

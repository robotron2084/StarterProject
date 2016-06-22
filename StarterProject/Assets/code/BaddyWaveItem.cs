using UnityEngine;

[System.Serializable]
public class BaddyWaveItem
{
  public Baddy baddyPrefab;
  public Vector3 posDelta;
  public float speedModifier = 0.0f;
  public float spawnTime = 1.0f;
}

using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]private List<SpawnObjectsStats> _objectsToSpawn;
    [SerializeField] private Vector2 xRange;
    [SerializeField] private Vector2 yRange;

    public static ItemSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnRandomItemAtRandomPosition()
    {
        Vector3 randomPos = new Vector3(UnityEngine.Random.Range(xRange.x, xRange.y), UnityEngine.Random.Range(yRange.x, yRange.y), -1);
        SpawnRandomItem(randomPos);
    }

    public void SpawnRandomItem(Vector3 position)
    {
        SpawnObjectsStats spawnObjectsStats = _objectsToSpawn[UnityEngine.Random.Range(0, _objectsToSpawn.Count)];
        ItemStats stats = spawnObjectsStats.CompatibleStats[UnityEngine.Random.Range(0, spawnObjectsStats.CompatibleStats.Count)];
        GameObject obj = Instantiate(spawnObjectsStats.ObjectToSpawn.gameObject, position, Quaternion.identity);

        Item item = obj.GetComponent<Item>();
        if (item is PickupableItem pickup)
            pickup.Initialize(stats);
        else
            item.Stats = stats;
    }
}

[Serializable]
public struct SpawnObjectsStats
{
    public GameObject ObjectToSpawn;
    public List<ItemStats> CompatibleStats;
}
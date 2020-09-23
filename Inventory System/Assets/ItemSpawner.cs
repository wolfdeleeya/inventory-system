using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField]private List<SpawnObjectsStats> _objectsToSpawn;

    public static ItemSpawner Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SpawnRandomItem(Vector3 position)
    {
        SpawnObjectsStats spawnObjectsStats = _objectsToSpawn[UnityEngine.Random.Range(0, _objectsToSpawn.Count)];
        ItemStats stats = spawnObjectsStats.CompatibleStats[UnityEngine.Random.Range(0, spawnObjectsStats.CompatibleStats.Count)];
        GameObject obj = Instantiate(spawnObjectsStats.ObjectToSpawn.gameObject, position, Quaternion.identity);
        obj.GetComponent<Item>().Stats = stats;
    }
}

[Serializable]
public struct SpawnObjectsStats
{
    public GameObject ObjectToSpawn;
    public List<ItemStats> CompatibleStats;
}
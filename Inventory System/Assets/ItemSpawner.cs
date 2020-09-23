using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField]private List<GameObject> objectsToSpawn;

    public ItemSpawner Instance { get; private set; }

    public void SpawnRandomItem(Vector3 position)
    {

    }
}

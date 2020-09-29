using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance { get; private set; }
    public List<GameObject> BuffPrefabs;

    private Transform _transform;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _transform = GetComponent<Transform>();
    }

    public void SpawnBuff(ItemBuffStats stats)
    {
        ItemBuff buff = Instantiate(BuffPrefabs[(int)stats.Type],_transform).GetComponent<ItemBuff>();
        buff.Initialize(stats);
    }
}

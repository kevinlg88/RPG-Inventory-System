using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private int spawnedCount = 0;
    private int maxItemSpawned;

    [Header("SpawnPoints")]
    public List<GameObject> spawnPoints = new List<GameObject>();

    [Header("Items")]
    public List<PriorityItemSpawn> items = new List<PriorityItemSpawn>();

    void Start()
    {
        maxItemSpawned = spawnPoints.Count;
        SpawnItens();
    }

    private void SpawnItens()
    {
        List<float> probs = new List<float>();
        foreach (PriorityItemSpawn item in items)
        {
            probs.Add(item.probability);
        }
        foreach (GameObject point in spawnPoints)
        {
            GameObject item = items[ChooseItem(probs)].itemPrefab;
            GameObject goSpawnedItem = Instantiate(item, point.transform.position, Quaternion.identity);
            goSpawnedItem.TryGetComponent<ItemPickup>(out ItemPickup component);
            component.OnPickup += VerifyItemsCount;
            spawnedCount++;
        }
    }

    private void VerifyItemsCount(ItemPickup item)
    {
        item.OnPickup -= VerifyItemsCount;
        spawnedCount--;
        if(spawnedCount == 0)
        {
            Invoke("SpawnItens",3);
        }
    }

    int ChooseItem (List<float> probs)
    {

        float total = 0;

        foreach (float elem in probs) {
            total += elem;
        }

        float randomPoint = UnityEngine.Random.value * total;

        for (int i= 0; i < probs.Count; i++) {
            if (randomPoint < probs[i]) {
                return i;
            }
            else {
                randomPoint -= probs[i];
            }
        }
        return probs.Count - 1;
    }

}

[Serializable]
public class PriorityItemSpawn
{
    [Range(0f, 1f)]
    public float probability;
    public GameObject itemPrefab;
}

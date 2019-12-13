using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    public List<Transform> spawnPoisitions = new List<Transform>();

    private void Start()
    {
        InvokeRepeating("Spawn", 0, 4);
    }

    void Spawn()
    {
        if(spawnPoisitions.Count > 0)
        {
            
            int choosenInt = Random.Range(0, spawnPoisitions.Count - 1);
            Transform choosenPos = spawnPoisitions[choosenInt];
            GameObject newPrefab = Instantiate(prefab, choosenPos);
            newPrefab.GetComponent<Enemy>().myPosition = choosenPos;
            newPrefab.transform.position = new Vector2(newPrefab.transform.position.x, newPrefab.transform.position.y - 26.7f);
            spawnPoisitions.RemoveAt(choosenInt);
            
        }
    }

   

}

using System.Collections.Generic;
using UnityEngine;


public class BarrierSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject barrierPrefab;
    [SerializeField] private List<int> randomRoadSelection = new List<int>
    {
        -3, 0, 3
    };

   
    private void SpawnPosition()
    {
      //TODO: Barrier Random Spawn.
    }
}
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager Instance { get; private set; }
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private Vector3 newSpawnPos;
    public GameObject spawnedRoad;
    [SerializeField]private List<GameObject> roadList = new List<GameObject>();
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // public Vector3 ChangeSpawnPos
    // {
    //     get { return newSpawnPos; }
    //     set { newSpawnPos = value; }
    // }

    public void Start()
    {
        CreateNewRoad();
    }

    public void SpawnRoad()
    {
        GameObject temp = Instantiate(roadPrefab, newSpawnPos, Quaternion.identity);
        newSpawnPos = temp.transform.GetChild(1).transform.position;
        temp.name = "road";
        spawnedRoad = temp;
        roadList.Add(spawnedRoad);
    }

    public void ResetSpawned()
    {
        foreach (var t in roadList)
            Destroy(t);

        roadList.Clear();
        newSpawnPos = Vector3.zero;
        CreateNewRoad();
    }

    private void CreateNewRoad()
    {
        for(var i=0;i<15;i++)
            SpawnRoad();
    }
    
}
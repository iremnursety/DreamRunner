using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    { 
        if (!other.CompareTag("Player")) return;
        else
        {
            //var objRoadController = gameObject.transform.parent.GetComponent<RoadController>();
            //objRoadController.SpawnRoad();
            RoadManager.Instance.SpawnRoad();
            Destroy(gameObject,2f);
        }
    }
}

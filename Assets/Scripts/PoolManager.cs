using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{

    private const int defaultPoolSize = 5;
    [SerializeField] private GameObject obstaclePrefab;

    private List<GameObject> obstacles = new List<GameObject>();

    private void generatePool(GameObject prefab, List<GameObject> pool, int amount = defaultPoolSize) {
        for(int i = 0; i < amount; i++) {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);
            pool.Add(newObject);
        }
    }

    private GameObject getObjectFromPool(List<GameObject> pool) {
        GameObject obj = null;
        foreach(GameObject objInPool in pool) {
            if(!objInPool.activeInHierarchy) {
                obj = objInPool;
            }
        }
        if(obj == null) {
            GameObject newObj = Instantiate(obstaclePrefab);
            obj = newObj;
            obstacles.Add(newObj);
        }
        obj.SetActive(true);
        return obj;
    }

    public GameObject getObstacle() {
        GameObject newObstacle = getObjectFromPool(obstacles);
        return newObstacle;
    }

    void Start() {
        generatePool(obstaclePrefab, obstacles);
    }

}

using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;

    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 0.3f){
            timer = 0;
            Spawn();
        }
    }

    void Spawn(){
        int prefabLength = GameManager.instance.poolManager.prefabs.Length;
        GameObject enemy = GameManager.instance.poolManager.Get(Random.Range(0, prefabLength));
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
    }
}

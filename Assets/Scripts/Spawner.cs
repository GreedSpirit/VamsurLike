using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public Spawndata[] spawndata;

    float timer;
    int level;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (!GameManager.instance.isLive) return;
        
        timer += Time.deltaTime;
        level = Mathf.Min(spawndata.Length - 1, Mathf.FloorToInt(GameManager.instance.gameTime / 10f));

        if(timer > spawndata[level].spawnTime){
            timer = 0;
            Spawn();
        }
    }

    void Spawn(){
        GameObject enemy = GameManager.instance.poolManager.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawndata[level]);
    }
}

[System.Serializable]
public class Spawndata{
    public int spriteType;
    public float spawnTime;
    public float speed;
    public float health;

}

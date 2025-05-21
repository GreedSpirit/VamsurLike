using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Object")]
    public Player player;
    public PoolManager poolManager;
    [Header("# Game Control")]
    public float gameTime = 0;
    public float maxgameTime = 2 * 10f - 1;
    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {3, 5, 10, 20, 40, 80, 150, 300, 600, 1200};



    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if(gameTime >= maxgameTime){
            gameTime = maxgameTime;
        }
    }

    public void GetExp(){
        exp++;

        if(exp == nextExp[level]){
            level++;
            exp = 0;
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Object")]
    public Player player;
    public PoolManager poolManager;
    public LevelUp uiLevelUp;
    [Header("# Game Control")]
    public float gameTime = 0;
    public float maxgameTime = 2 * 10f - 1;
    public bool isLive = true;
    [Header("# Player Info")]
    public int health;
    public int maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 20, 40, 80, 150, 300, 600, 1200 };



    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        health = maxHealth;

        //베이스 무기 임시 스크립트
        uiLevelUp.Select(0);
    }

    void Update()
    {
        if (!isLive) return;

        gameTime += Time.deltaTime;
        if (gameTime >= maxgameTime)
        {
            gameTime = maxgameTime;
        }
    }

    public void GetExp()
    {
        exp++;

        if (exp == nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }
}

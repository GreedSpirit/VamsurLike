using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public PoolManager poolManager;

    public float gameTime = 0;
    public float maxgameTime = 2 * 10f - 1;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if(gameTime >= maxgameTime){
            gameTime = maxgameTime;
        }
    }
}

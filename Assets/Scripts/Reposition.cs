using UnityEngine;

public class Reposition : MonoBehaviour
{
    private float tileSize = 20;

    Collider2D col;

    void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    // 멀리 떨어진 몬스터의 재소환 또는 무한 맵을 구현하기 위한 스크립트
    void OnTriggerExit2D(Collider2D other) {
        if(!other.CompareTag("Area")) return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 thisPos = transform.position;

        float difx = Mathf.Abs(playerPos.x - thisPos.x);
        float dify = Mathf.Abs(playerPos.y - thisPos.y);

        float dirx = playerPos.x - thisPos.x;
        float diry = playerPos.y - thisPos.y;

        dirx = dirx < 0 ? -1 : 1;
        diry = diry < 0 ? -1 : 1;

        switch(transform.tag){
            case "Ground" :
                if(difx > dify){
                    transform.Translate(Vector3.right * dirx * (tileSize * 2));
                }
                else if(dify > difx){
                    transform.Translate(Vector3.up * diry * (tileSize * 2));
                }
                else{
                    transform.Translate(Vector3.right * dirx * (tileSize * 2));
                    transform.Translate(Vector3.up * diry * (tileSize * 2));
                }
            break;

            case "Enemy" :
                if(col.enabled){
                    Vector2 playerdir = GameManager.instance.player.inputVec;
                    transform.Translate(playerdir * tileSize + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                }
            break;
        }
    }
}

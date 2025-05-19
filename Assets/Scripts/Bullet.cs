using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float per;
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, float per, Vector3 dir){
        this.damage = damage;
        this.per = per;

        if(per > -1) rigid.linearVelocity = dir * 15f;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag("Enemy") || per == -1) return;

        per--;
        if(per == -1){
            rigid.linearVelocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
}

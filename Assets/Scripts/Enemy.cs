using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    public float speed;

    bool isLive;
    SpriteRenderer spriter;
    Rigidbody2D rigid;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 dirvec = target.position - rigid.position;
        Vector2 nextvec = dirvec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
        rigid.linearVelocity = Vector2.zero;

    }

    void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
}

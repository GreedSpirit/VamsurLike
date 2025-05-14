using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D target;
    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animatorController;

    bool isLive;
    SpriteRenderer spriter;
    Rigidbody2D rigid;
    Animator animator;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if(!isLive) return;

        Vector2 dirvec = target.position - rigid.position;
        Vector2 nextvec = dirvec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
        rigid.linearVelocity = Vector2.zero;

    }

    void LateUpdate()
    {
        if(!isLive) return;
        
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(Spawndata data){
        animator.runtimeAnimatorController = animatorController[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = maxHealth;
    }
}

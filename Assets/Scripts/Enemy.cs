using System.Collections;
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
    WaitForFixedUpdate wait;
    Collider2D enemyCollider;

    void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
        enemyCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isLive) return;
        if (!isLive || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit")) return;

        Vector2 dirvec = target.position - rigid.position;
        Vector2 nextvec = dirvec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextvec);
        rigid.linearVelocity = Vector2.zero;

    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive) return;
        if (!isLive) return;
        
        spriter.flipX = target.position.x < rigid.position.x;
    }

    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        rigid.simulated = true;
        enemyCollider.enabled = true;
        animator.SetBool("Dead", false);
        //gameObject.SetActive(true);
        spriter.sortingOrder++;


        health = maxHealth;
    }

    public void Init(Spawndata data){
        animator.runtimeAnimatorController = animatorController[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet") && isLive){
            this.health -= other.GetComponent<Bullet>().damage;
            
            if(this.health > 0){
                StartCoroutine(KnockBack());
                animator.SetTrigger("Hit");

            }
            else{ //Dead
                isLive = false;
                rigid.simulated = false;
                enemyCollider.enabled = false;
                animator.SetBool("Dead", true);
                spriter.sortingOrder--;
                GameManager.instance.kill++;
                GameManager.instance.GetExp();
            }
        }
    }

    IEnumerator KnockBack(){
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 4, ForceMode2D.Impulse);
    }

    public void Dead(){
        gameObject.SetActive(false);
    }
}

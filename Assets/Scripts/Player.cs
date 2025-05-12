using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    SpriteRenderer spriteRenderer;
    Animator animator;

    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value){
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate()
    {
        spriteRenderer.flipX = inputVec.x < 0;
        animator.SetFloat("Speed", inputVec.magnitude);
    }


}

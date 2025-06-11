
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damage;
    public float count;
    public float speed;

    float fireTimer;
    Player player;

    void Awake()
    {
        player = GameManager.instance.player;
    }

    void Update()
    {
        if (!GameManager.instance.isLive) return;
        
        switch (id)
        {
            case 0:
                transform.Rotate(speed * Time.deltaTime * Vector3.back);
                break;

            case 1:
                fireTimer += Time.deltaTime;
                if (fireTimer > speed)
                {
                    fireTimer = 0;
                    Fire();
                }
                break;

            default:
                break;
        }

        if(Input.GetButtonDown("Jump")){ // Test Code
            LevelUp(30, 5);
        }
    }

    public void LevelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
        {
            Place();
        }
        
        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Weapon " + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        id = data.itemId;
        damage = data.baseDamage * Character.Damage;
        count = data.baseCount + Character.Count;

        for (int idx = 0; idx < GameManager.instance.poolManager.prefabs.Length; idx++)
        {
            if (data.projectile == GameManager.instance.poolManager.prefabs[idx])
            {
                prefabId = idx;
                break;
            }
        }

        switch (id)
        {
            case 0:
                speed = 150 * Character.WeaponSpeed;
                Place();
                break;

            case 1:
                speed = 0.3f * Character.WeaponRate;
                break;

            default:
                break;
        }

        //Hand Set
        Hand hand = player.hands[(int)data.itemtype];
        hand.spriter.sprite = data.hand;
        hand.gameObject.SetActive(true);

        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    void Place(){
        for(int idx = 0; idx < count; idx++){
            Transform bulletTransform;

            if(transform.childCount > idx){
                bulletTransform = transform.GetChild(idx);
            }
            else{
                bulletTransform = GameManager.instance.poolManager.Get(prefabId).transform;
                bulletTransform.parent = this.transform;
            }

            bulletTransform.localPosition = Vector3.zero;
            bulletTransform.localRotation = Quaternion.identity;

            Vector3 rotateVec = 360 * idx * Vector3.forward / count;

            bulletTransform.Rotate(rotateVec);
            bulletTransform.Translate(Vector3.up * 1.5f, Space.Self);

            bulletTransform.GetComponent<Bullet>().Init(damage, -1, Vector3.zero); // -1 is Inf Per.
        }
        
    }

    void Fire()
    {
        if (!player.scanner.nearestTarget) return;

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 fireDir = targetPos - transform.position;
        fireDir = fireDir.normalized;

        Transform bullet = GameManager.instance.poolManager.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, fireDir);

        bullet.GetComponent<Bullet>().Init(damage, count, fireDir);
        
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Range);
    }
}

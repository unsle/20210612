using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNav : MonoBehaviour, IDamageable
{
    public GameObject monsterhp;
    private Transform _monster;
    private Transform _player;
    private UnityEngine.AI.NavMeshAgent nvAgent;
    public GameObject star;

    public GameObject playerHP;
    Animator animator;

    public float watchDistance; // 플레이어를 발견하는 거리
    private float onDamageDistance = 1f; // 플레이어에게 데미지를 입히는 거리
    private float attackTime = 2f; // 공격간 시간
    private float next = 0.0f;

    public int MaxHP;
    private int HP;

    private Rigidbody monsterRigidbody;
    public float rotateSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
        monsterRigidbody = GetComponent<Rigidbody>();
        nvAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        attackTime = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        _monster = gameObject.GetComponent<Transform>();
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();

        if (Vector3.Distance(_monster.position, _player.position) <= watchDistance)
        {
            nvAgent.destination = _player.position;
            _monster.rotation = Quaternion.LookRotation(_player.position - _monster.position);
            animator.SetBool("Move", true);
            if (Vector3.Distance(_monster.position, _player.position) <= onDamageDistance)
            {
                if (Time.time > next)
                {
                    next = Time.time + attackTime;
                    animator.SetBool("Attack", true);
                    OnDamage(1);
                }
                animator.SetBool("Attack", false);
            }
        }
        animator.SetBool("Move", false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            Debug.Log("Weapon 충돌");
            _OnDamage();
        }
    }

    public void _OnDamage()
    {    
        HP--;
        Debug.Log(HP);
        monsterhp.GetComponent<MonsterHP>().OnDamage(1);
        if (HP == 0)
        {
            Debug.Log("die");
            animator.SetTrigger("Die");
            Destroy(gameObject);

            GameObject[] spawn = GameObject.FindGameObjectsWithTag("Monster");
            Debug.Log("남은 몬스터 : " + spawn.Length);

            if (spawn.Length == 1)
            {
                Debug.Log("win");
                star.gameObject.SetActive(true);
            }
        }
    }

    public void OnDamage(int damage)
    {
        playerHP.GetComponent<PlayerHealth>().OnDamage(damage);
    }
}
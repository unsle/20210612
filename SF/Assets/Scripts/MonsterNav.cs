using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterNav : MonoBehaviour, IDamageable
{
    private Transform _monster;
    private Transform _player;
    private UnityEngine.AI.NavMeshAgent nvAgent;

    public GameObject playerHP;

    public float watchDistance; // 플레이어를 발견하는 거리
    private float onDamageDistance = 1f; // 플레이어에게 데미지를 입히는 거리
    private float attackTime = 2f; // 공격간 시간
    private float next = 0.0f;

    private Rigidbody monsterRigidbody;
    public float rotateSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        monsterRigidbody = GetComponent<Rigidbody>();
        nvAgent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
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
            if(Vector3.Distance(_monster.position, _player.position) <= onDamageDistance)
            {
                if (Time.time > next)
                {
                    next = Time.time + attackTime;
                    OnDamage(1);
                }
            }
        }
    }

    public void OnDamage(int damage)
    {
        playerHP.GetComponent<PlayerHealth>().OnDamage(damage);
    }
}

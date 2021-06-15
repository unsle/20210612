/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public GameObject male;
    public GameObject female;
    Animator animator;

    private GameObject playerSexual;
    private bool isMale;

    public float speed = 8f;
    public float rotateSpeed = 8f;

    private float xInput;
    private float zInput;
    private float attackTime = 0.25f;
    private float next;
    //private bool isAtack;

    private Vector3 movement;

    void Start()
    {
        // PlayerSexual sex = GetComponent<PlayerSexual>();
        isMale = false;
        playerRigidbody = GetComponent<Rigidbody>();
        if (isMale) animator = male.GetComponent<Animator>();
        else animator = female.GetComponent<Animator>();
        next = Time.time;
        //isAtack = false;
    }

    void Update()
    {
        Move();

        Atack();

        //if (Time.time == next)
        //{
        //animator.SetBool("Attack", false);
        //}

        //if (Time.time >= next)
        //{

        //}
        //if (Time.time == next)
        //Atack(false);
    }

    void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        if (xInput == 0 && zInput == 0)
        {
            animator.SetBool("Move", false);
        }

        movement.Set(xInput, 0, zInput);
        movement = movement.normalized * speed * Time.deltaTime;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        if (movement.x != 0 || movement.z != 0)
        {
            Turn();
        }
        else
        {
            animator.SetBool("Move", false);
            return;
        }
    }

    void Atack()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            next = Time.time + attackTime;
            //Debug.Log("start" + Time.time + " " + next);
            animator.SetBool("Attack", true);
        }
        //if (Input.GetKeyUp(KeyCode.P))
        if (Time.time > next)
        {
            //Debug.Log("Stop" + Time.time);
            animator.SetBool("Attack", false);
        }
    }

    void Turn()
    {
        animator.SetBool("Move", true);
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(xInput, 0, zInput));
        playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void Die()
    {
        animator.SetTrigger("Die");
    }
}
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public GameObject male;
    public GameObject female;
    public GameObject Bullet;
    public Transform FirePos;
    Animator animator;

    //private GameObject playerSexual;
    private bool isMale;
    private bool isMage;

    public float speed = 8f;
    public float rotateSpeed = 8f;

    private float xInput;
    private float zInput;
    private float attackTime = 0.25f;
    private float next;
    //private bool isAtack;

    private Vector3 movement;

    void Start()
    {
        //PlayerSexual sex = ;
        isMale = false;
        //isMage = GetComponent<UI_Weapon>().isMage();
        playerRigidbody = GetComponent<Rigidbody>();
        if (isMale) animator = male.GetComponent<Animator>();
        else animator = female.GetComponent<Animator>();
        next = Time.time;
    }

    void Update()
    {
        Move();

        Atack();
    }

    void Move()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        if (xInput == 0 && zInput == 0)
        {
            animator.SetBool("Move", false);
        }

        movement.Set(xInput, 0, zInput);
        movement = movement.normalized * speed * Time.deltaTime;

        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newVelocity;

        if (movement.x != 0 || movement.z != 0)
        {
            Turn();
        }
        else
        {
            animator.SetBool("Move", false);
            return;
        }
    }

    void Atack()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            next = Time.time + attackTime;
            //Debug.Log("start" + Time.time + " " + next);
            animator.SetBool("Attack", true);
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
        }
        //if (Input.GetKeyUp(KeyCode.P))
        if (Time.time > next)
        {
            //Debug.Log("Stop" + Time.time);
            animator.SetBool("Attack", false);
        }
    }

    void Turn()
    {
        animator.SetBool("Move", true);
        Quaternion newRotation = Quaternion.LookRotation(new Vector3(xInput, 0, zInput));
        playerRigidbody.rotation = Quaternion.Slerp(playerRigidbody.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }

    void Die()
    {
        animator.SetTrigger("Die");
    }
}
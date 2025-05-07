using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator; // �ִϸ����� ����
    Rigidbody2D _rigidbody; // rigidbody ����

    [SerializeField] private float flapForce = 6f; //���� ��
    [SerializeField] private float forwardSpeed = 3f; // �������� �̵��ϴ� ��
    [SerializeField] private bool isDead = false; // ���� ����
    float deathCooldown = 0f; //���� �ð� �Ŀ� ���� ����

    bool isFlap = false; // ���� ���� Ȯ��

    [SerializeField] private bool godMode = false; // ������ ���(���� �׽�Ʈ ����) 

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();  //GetComponent<>() : Animator ������Ʈ �˻�,(InChildren) :  �ڽ� ��ü���� �˻�
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator"); //Animator ����ó��
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody"); //Rigidbody ����ó��
        }
    }

    // Update is called once per frame
    void Update() //�����Ӹ��� ���
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //���� �����
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime; // ��ٿ� ����
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  // GetKeyDown(Ű �Է�) : �����̽� or ���� Ŭ��
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity; //velocity ���ӵ�
        velocity.x = forwardSpeed; //veolcity.x�� ������ forwardSpeed ����

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        _rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return; // ������ ���

        if (isDead) return; // ���

        isDead = true; // ĳ���� ���
        deathCooldown = 1f; //��ٿ� �ð� �Ҵ�

        animator.SetInteger("IsDie", 1); // ���� �ִϸ��̼� ����
        gameManager.GameOver(); // ���� ����
    }
}

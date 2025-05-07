using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator; // 애니메이터 선언
    Rigidbody2D _rigidbody; // rigidbody 선언

    [SerializeField] private float flapForce = 6f; //점프 힘
    [SerializeField] private float forwardSpeed = 3f; // 정면으로 이동하는 힘
    [SerializeField] private bool isDead = false; // 생사 구분
    float deathCooldown = 0f; //일정 시간 후에 죽음 판정

    bool isFlap = false; // 점프 유무 확인

    [SerializeField] private bool godMode = false; // 에디터 모드(게임 테스트 위함) 

    GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();  //GetComponent<>() : Animator 컴포넌트 검색,(InChildren) :  자식 개체에도 검색
        _rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            Debug.LogError("Not Founded Animator"); //Animator 예외처리
        }

        if (_rigidbody == null)
        {
            Debug.LogError("Not Founded Rigidbody"); //Rigidbody 예외처리
        }
    }

    // Update is called once per frame
    void Update() //프레임마다 계속
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime; // 쿨다운 시작
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))  // GetKeyDown(키 입력) : 스페이스 or 왼쪽 클릭
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity; //velocity 가속도
        velocity.x = forwardSpeed; //veolcity.x에 선언한 forwardSpeed 대입

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
        if (godMode) return; // 관리자 모드

        if (isDead) return; // 사망

        isDead = true; // 캐릭터 사망
        deathCooldown = 1f; //쿨다운 시간 할당

        animator.SetInteger("IsDie", 1); // 죽음 애니메이션 시작
        gameManager.GameOver(); // 게임 오버
    }
}

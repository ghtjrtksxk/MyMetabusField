using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target; //Player
    float offsetX;

    void Start()
    {
        if (target == null)
            return;

        offsetX = transform.position.x - target.position.x; // 카메라와 플레이어의 x값 차이를 offsetX에 저장
    }
    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position; //transform.position.x 는 직접 바꿀 수 있는 값이 아님, 포지션을 바꿀 때는 변수에 한번 저장하고 사용
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}

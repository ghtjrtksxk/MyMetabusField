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

        offsetX = transform.position.x - target.position.x; // ī�޶�� �÷��̾��� x�� ���̸� offsetX�� ����
    }
    void Update()
    {
        if (target == null)
            return;

        Vector3 pos = transform.position; //transform.position.x �� ���� �ٲ� �� �ִ� ���� �ƴ�, �������� �ٲ� ���� ������ �ѹ� �����ϰ� ���
        pos.x = target.position.x + offsetX;
        transform.position = pos;
    }
}

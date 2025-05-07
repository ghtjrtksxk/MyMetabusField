using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float highPosY = 1f; // õ�� ��ֹ� ��ġ
    [SerializeField] private float lowPosY = -1f; // �ٴ� ��ֹ� ��ġ

    [SerializeField] private float holeSizeMin = 1f; // ���Ʒ� ��ֹ� ���� �� �ּҰ�
    [SerializeField] private float holeSizeMax = 3f; // ���Ʒ� ��ֹ� ���� �� �ִ밪

    [SerializeField] private Transform topObject;
    [SerializeField] private Transform bottomObject;

    [SerializeField] private float widthPadding = 4f; //������Ʈ ���� �� �� (���� ��)

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax); //holeSize ���� �Ҵ�
        float halfHoleSize = holeSize / 2; //�Ҵ�� holeSize�� �ݰ�

        topObject.localPosition = new Vector3(0, halfHoleSize); //õ�� ��ֹ��� ��ġ y��
        bottomObject.localPosition = new Vector3(0, -halfHoleSize); // �ٴ� ��ֹ��� ��ġ y��

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // ���� ������ ������ ���¿��� ����
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            gameManager.AddScore(1);
    }
}

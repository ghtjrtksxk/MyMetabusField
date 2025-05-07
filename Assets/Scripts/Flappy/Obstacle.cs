using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float highPosY = 1f; // 천장 장애물 위치
    [SerializeField] private float lowPosY = -1f; // 바닥 장애물 위치

    [SerializeField] private float holeSizeMin = 1f; // 위아래 장애물 사이 폭 최소값
    [SerializeField] private float holeSizeMax = 3f; // 위아래 장애물 사이 폭 최대값

    [SerializeField] private Transform topObject;
    [SerializeField] private Transform bottomObject;

    [SerializeField] private float widthPadding = 4f; //오브젝트 생성 시 폭 (가로 폭)

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax); //holeSize 랜덤 할당
        float halfHoleSize = holeSize / 2; //할당된 holeSize의 반값

        topObject.localPosition = new Vector3(0, halfHoleSize); //천장 장애물의 위치 y값
        bottomObject.localPosition = new Vector3(0, -halfHoleSize); // 바닥 장애물의 위치 y값

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0); // 가로 간격을 유지한 상태에서 생성
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

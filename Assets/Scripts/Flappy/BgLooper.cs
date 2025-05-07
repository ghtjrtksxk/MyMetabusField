using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    [SerializeField] private int numBgCount = 5;
    [SerializeField] private int obstacleCount = 0;
    [SerializeField] private Vector3 obstacleLastPosition;

    void Start()
    {
        obstacleLastPosition = new Vector3(8, 0);

        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // Objstacle ������Ʈ�� ã�� �迭�� �־���
        obstacleCount = obstacles.Length; //obstacles�� ����

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd: " + collision.name);

        //�±׷� ã��
        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        //Obstacle ������Ʈ�� �ִ� ������Ʈ�� ã��
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}

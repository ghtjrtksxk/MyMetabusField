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

        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); // Objstacle 컴포넌트를 찾아 배열에 넣어줌
        obstacleCount = obstacles.Length; //obstacles의 길이

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggerd: " + collision.name);

        //태그로 찾음
        if (collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        //Obstacle 컴포넌트가 있는 오브젝트를 찾음
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}

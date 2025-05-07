using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //가로
        float vertical = Input.GetAxisRaw("Vertical"); //세로
        movementDirection = new Vector2(horizontal, vertical).normalized; // horizontal, vertical 의 방향은 유지하면서 크기를 1로 정규화

        // movementDirection의 정보

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition); //포인터 위치값 저장
        lookDirection = (worldPos - (Vector2)transform.position);

        // lookDirection의 정보

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}

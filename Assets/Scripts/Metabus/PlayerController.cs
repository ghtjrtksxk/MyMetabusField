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
        float horizontal = Input.GetAxisRaw("Horizontal"); //����
        float vertical = Input.GetAxisRaw("Vertical"); //����
        movementDirection = new Vector2(horizontal, vertical).normalized; // horizontal, vertical �� ������ �����ϸ鼭 ũ�⸦ 1�� ����ȭ

        // movementDirection�� ����

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition); //������ ��ġ�� ����
        lookDirection = (worldPos - (Vector2)transform.position);

        // lookDirection�� ����

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

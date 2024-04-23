using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도
    public float rotationSpeed = 90f; // 회전 속도

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

        // 플레이어를 이동 방향으로 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // O 키를 누르면 왼쪽으로 90도 회전, P 키를 누르면 오른쪽으로 90도 회전
        if (Input.GetKeyDown(KeyCode.O))
        {
            RotateCameraAroundPlayer(-rotationSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            RotateCameraAroundPlayer(rotationSpeed);
        }
    }

    // 메인 카메라를 스크립트가 연결된 오브젝트를 중심으로 회전하는 함수
    void RotateCameraAroundPlayer(float angle)
    {
        // 스크립트가 연결된 오브젝트를 중심으로 메인 카메라를 회전
        Vector3 pivot = transform.position;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        Camera.main.transform.RotateAround(pivot, Vector3.up, angle);
    }
}

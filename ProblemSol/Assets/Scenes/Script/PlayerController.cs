using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public float rotationSpeed = 90f; // ȸ�� �ӵ�

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        Vector3 moveDirection = cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput;

        // �÷��̾ �̵� �������� �̵�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // O Ű�� ������ �������� 90�� ȸ��, P Ű�� ������ ���������� 90�� ȸ��
        if (Input.GetKeyDown(KeyCode.O))
        {
            RotateCameraAroundPlayer(-rotationSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            RotateCameraAroundPlayer(rotationSpeed);
        }
    }

    // ���� ī�޶� ��ũ��Ʈ�� ����� ������Ʈ�� �߽����� ȸ���ϴ� �Լ�
    void RotateCameraAroundPlayer(float angle)
    {
        // ��ũ��Ʈ�� ����� ������Ʈ�� �߽����� ���� ī�޶� ȸ��
        Vector3 pivot = transform.position;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        Camera.main.transform.RotateAround(pivot, Vector3.up, angle);
    }
}

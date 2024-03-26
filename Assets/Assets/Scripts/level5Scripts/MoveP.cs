using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveP : MonoBehaviour
{
    public float speed = 10f; // �������� �������� �������

    void Update()
    {
        // �������� ���� � ���������� �� ��� �����������
        float horizontalInput = Input.GetAxis("Horizontal");

        // ������������ ������ �������� �� ������ �����
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;


        // �������� ������ ������ � ������� �����������
        float screenWidth = Camera.main.aspect * Camera.main.orthographicSize;

        // ������������ ���������� X ������� ��������� � �������� ������ ������
        float clampedX = Mathf.Clamp(transform.position.x + movement.x, -screenWidth, screenWidth);

        // ��������� ������������ �������� � ������� �������
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}


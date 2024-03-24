using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    public float speed = 5f; // �������� �������� �������

    void Update()
    {
        // �������� ���� � ���������� �� ��� �����������
        float horizontalInput = Input.GetAxis("Horizontal");

        // ������������ ������ �������� �� ������ �����
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * speed * Time.deltaTime;

        // ��������� �������� � ������� �������
        transform.position += movement;
    }
}

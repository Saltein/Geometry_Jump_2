using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLook : MonoBehaviour
{
    public Transform head; // ������ �� Transform ������ ���������

    void Update()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ���������� ��������� �� ��� Z, ����� ������ �� ��������� ������ ������
        cursorPosition.z = 0f;

        // ������������ ����������� ������� �� ������
        Vector3 direction = cursorPosition - head.position;

        // ������������ ������� ������ � �������
        Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);

        // ��������� ������� � ������
        head.rotation = lookRotation;
    }
}

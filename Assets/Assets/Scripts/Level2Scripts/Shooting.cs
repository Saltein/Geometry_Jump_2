using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public float bulletSpeed = 10f; // �������� ������ ����
    public float maxDistance = 10f; // ������������ ���������� ������ ����

    void Update()
    {
        // ���������, ������ �� ������� ��� �������� (��������, ����� ������ ����)
        if (Input.GetButtonDown("Fire1"))
        {
            // ������� ����� ���� �� �������
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            // �������� ������� ������� � ������� �����������
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cursorPosition.z = 0f;

            // ������������ ����������� ������ ���� � �������
            Vector3 shootDirection = (cursorPosition - transform.position).normalized;

            // ��������� �������� ������ � ����������� ����
            Vector3 velocity = shootDirection * bulletSpeed;

            // �������� �������� ���� � �� Rigidbody2D (���� �� ����)
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = velocity;
            }

            // ���������� ���� ����� ������������ ����� ��� ��� ���������� ������������� ����������
            Destroy(bullet, maxDistance / bulletSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAttack1 : MonoBehaviour
{
    public float speed = 5f; // �������� �������� �����
    private DoodManager doodManager;
    private Transform target; // ���� ��� �������� (������)

    Vector3 targetPos;

    void Start()
    {
        // ������� ������� ������ � ����� "Player" � ������������� ��� ��� ���� ��� ��������
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        targetPos = new Vector3(target.position.x, target.position.y - 3, target.position.z);
        // ���������, ��� ���� �����������
        if (target != null)
        {
            // ��������� ����������� �������� � ����
            Vector3 direction = (targetPos - transform.position).normalized;

            // ��������� ����������� ����� �� ����������� � ���� � ������ �������� � ������� �����
            Vector3 moveAmount = direction * speed * Time.deltaTime;

            // ���������� ���� �� ������������ ������� �����������
            transform.Translate(moveAmount);
        }
    }
}

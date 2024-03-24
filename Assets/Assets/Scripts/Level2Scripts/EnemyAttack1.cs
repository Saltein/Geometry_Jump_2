using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAttack1 : MonoBehaviour
{
    public float speed = 5f; // —корость движени€ врага
    private DoodManager doodManager;
    private Transform target; // ÷ель дл€ движени€ (дудлер)

    Vector3 targetPos;

    void Start()
    {
        // Ќаходим игровой объект с тегом "Player" и устанавливаем его как цель дл€ движени€
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        targetPos = new Vector3(target.position.x, target.position.y - 3, target.position.z);
        // ѕровер€ем, что цель установлена
        if (target != null)
        {
            // ¬ычисл€ем направление движени€ к цели
            Vector3 direction = (targetPos - transform.position).normalized;

            // ¬ычисл€ем перемещение врага по направлению к цели с учетом скорости и времени кадра
            Vector3 moveAmount = direction * speed * Time.deltaTime;

            // ѕеремещаем враг по вычисленному вектору перемещени€
            transform.Translate(moveAmount);
        }
    }
}

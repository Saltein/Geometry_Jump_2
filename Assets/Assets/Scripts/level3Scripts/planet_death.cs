using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_death : MonoBehaviour
{
    public Transform Player; // ��������
    public float speed; // �������� ���������� ������ �� ����������
    public GameObject Panel; // ������ �� Canvas.Panel
    public RectTransform ScoreTxt; // ������ �� Canvas.Text(TMP)
    // Start is called before the first frame update
    void Start()
    {
        Panel.SetActive(false); // ������������ Canvas.Panel
    }
    private void OnTriggerEnter2D(Collider2D collision) // ������������ � ������ �����
    {
        if (collision.gameObject.GetComponent<Doodler>()) // ��������, �������� �� ������ ������ ��������
        {
            Panel.SetActive(true); // ���������� Canvas.Panel
            ScoreTxt.localPosition = new Vector3(20, 150, 0);
            Destroy(gameObject); // ����������� ������� �������
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Player) // ���������� �� ��������, �.�. �� �������� ��� ������� � OnTriggerEnter2D
        {
            if (Player.position.y > transform.position.y) // ���������� ��������� �� Y > ���������� ������ �� Y
            {
                Vector3 CameraPosition = Player.position; // CameraPosition = ������� ���������� ���������
                CameraPosition.x = 0; // ���������� �� X ������ = 0, ����� ������ �� ��������� �� X
                CameraPosition.z = transform.position.z; // ��������� ���������� ������ �� Z
                transform.position = CameraPosition; // ������ ���������� ������ (�.�. ������ ������ ���������� �� Y)
            }
        }
    }
}

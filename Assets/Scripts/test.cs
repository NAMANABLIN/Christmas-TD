using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // �������� ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // ����� �������� ����� �������� ��������
            animator.ResetTrigger("hit");

            // ������ �������� ����� �������� hit, hit2, hit3 �� �������
            animator.SetTrigger("hit");
        }

        // �������� ������� ������� F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // ����� �������� ����� �������� ��������
            animator.ResetTrigger("look");

            // ������ �������� ����� ������� look
            animator.SetTrigger("look");
        }
    }
}
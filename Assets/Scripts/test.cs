using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // Проверка нажатия левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Сброс триггера перед запуском анимации
            animator.ResetTrigger("hit");

            // Запуск анимации через триггеры hit, hit2, hit3 по очереди
            animator.SetTrigger("hit");
        }

        // Проверка нажатия клавиши F
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Сброс триггера перед запуском анимации
            animator.ResetTrigger("look");

            // Запуск анимации через триггер look
            animator.SetTrigger("look");
        }
    }
}
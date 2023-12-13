using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform cameraRotation;
    private float xRotaion;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotaion -= mouseY;
        xRotaion = Mathf.Clamp(xRotaion, -80f, 80f);

        cameraRotation.localRotation = Quaternion.Euler(xRotaion, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
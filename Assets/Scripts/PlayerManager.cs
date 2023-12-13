using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private float startSpeed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private bool isGround = false;

    private void Awake()
    {
        startSpeed = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += speed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = startSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
            isGround = false;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(x, 0f, z);

        transform.Translate(move * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}

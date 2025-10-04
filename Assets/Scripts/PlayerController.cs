using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float runSpeed = 15f;

    public new Rigidbody rigidbody;
    [SerializeField] private Vector3 teleportationCoordinates;
    [SerializeField] private Animator doorAnimator;

    private bool isGround;

    private void Update()
    {
        if (transform.position.y <= 0 && SceneManager.GetActiveScene().buildIndex == 0)
            transform.position = teleportationCoordinates;
        if (doorAnimator != null)
        { 
            if (transform.position.y < 0.99f && SceneManager.GetActiveScene().buildIndex == 1)
            {
                if (doorAnimator.GetBool("isOpen"))
                    SceneManager.LoadScene(2);
                else
                    transform.position = teleportationCoordinates;
            }
        }
    }

    private void FixedUpdate()
    {
        rigidbody.linearVelocity = Vector3.zero;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _ = Input.GetAxisRaw("Mouse X");

        Vector3 velocity = new(h, 0, v);
        if (Input.GetKey(KeyCode.LeftControl))
            velocity *= runSpeed;
        else
            velocity *= walkSpeed;
        velocity.y = rigidbody.linearVelocity.y;
        Vector3 worldVelocity = transform.TransformVector(velocity);
        rigidbody.linearVelocity = worldVelocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") 
            isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGround = false;
    }
}

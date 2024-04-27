using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource doorOpenSource;
    [SerializeField] private AudioSource doorCloseSource;
    [SerializeField] private GameObject body;
    [SerializeField] private CameraController cameraController;

    void Update()
    {
        if (cameraController.LastHit == body && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (doorAnimator.GetBool("isOpen") == false)
            {
                doorAnimator.SetBool("isOpen", true);
                doorOpenSource.Play();
            }
            else if (doorAnimator.GetBool("isOpen") == true)
            {
                doorAnimator.SetBool("isOpen", false);
                doorCloseSource.Play();
            }
        }
    }
}

using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource doorOpenSource;
    [SerializeField] private AudioSource doorCloseSource;
    [SerializeField] private GameObject body;
    [SerializeField] private CameraController cameraController;

    private const string _isOpenKey = "isOpen";

    void Update()
    {
        if (cameraController.LastHit == body && Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (doorAnimator.GetBool(_isOpenKey) == false)
            {
                doorAnimator.SetBool(_isOpenKey, true);
                doorOpenSource.Play();
            }
            else if (doorAnimator.GetBool(_isOpenKey) == true)
            {
                doorAnimator.SetBool(_isOpenKey, false);
                doorCloseSource.Play();
            }
        }
    }
}

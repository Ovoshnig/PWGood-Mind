using UnityEngine;
using UnityEngine.UI;

public class DoorPassword : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Toggle toggle1;
    [SerializeField] private Toggle toggle2;
    [SerializeField] private Toggle toggle3;
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource levelCompleteSource;

    void Start()
    {
        canvas.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            canvas.enabled = !canvas.enabled;
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }
        if (toggle1.isOn && toggle2.isOn && toggle3.isOn && !doorAnimator.GetBool("isOpen"))
        {
            doorAnimator.SetBool("isOpen", true);
            levelCompleteSource.Play();
        }
    }
}

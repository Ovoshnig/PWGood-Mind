using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeStart = 60;
    public Text timerText;

    void Start() => timerText.text = timeStart.ToString();
    

    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();
        if (timeStart <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
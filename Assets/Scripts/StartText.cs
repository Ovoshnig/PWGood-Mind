using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartText : MonoBehaviour
{
    [SerializeField] private Image aim;
    [SerializeField] private Canvas startTextCanvas;
    [SerializeField] private Text[] startTexts;

    private int currentTextIndex = 0;

    void Start()
    {
        aim.enabled = false;
        foreach (var text in startTexts)
            text.enabled = false;
        if (startTexts.Length > 0)
        {
            startTexts[currentTextIndex].enabled = true;
            StartCoroutine(SwitchText());
        }
    }

    IEnumerator SwitchText()
    {
        yield return new WaitForSeconds(2);
        while (currentTextIndex < startTexts.Length - 1)
        {
            startTexts[currentTextIndex].enabled = false;
            currentTextIndex++;
            startTexts[currentTextIndex].enabled = true;
            yield return new WaitForSeconds(2);
        }
        startTextCanvas.enabled = false;
        aim.enabled = true;
    }
}

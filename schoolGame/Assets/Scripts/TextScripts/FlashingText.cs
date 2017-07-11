using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FlashingText : MonoBehaviour
{
    public Text currentText;

    void Start()
    {
        currentText = GetComponent<Text>();
    }
    void Update()
    {
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
           // yield return new WaitForSeconds(.75f);
           // currentText.text = "continue. . .";
            yield return new WaitForSeconds(.75f);
            currentText.text = "press enter to continue. . .";

            yield return new WaitForSeconds(.75f);
            currentText.text = null;
        }
    }

}
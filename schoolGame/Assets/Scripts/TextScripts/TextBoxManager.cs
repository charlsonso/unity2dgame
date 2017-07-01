using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour {
    public GameObject textBox;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endLine;
    public bool isActive;
    // Use this for initialization
    void Start () {
        if (textFile != null)
            textLines = textFile.text.Split('\n');
       if(endLine == 0)
            endLine = textLines.Length - 1;
        if (isActive)
            enableTextBox();
        if (!isActive)
            disableTextBox();
    }

    // Update is called once per frame
    void Update () {
        if (currentLine > endLine)
        {
            disableTextBox();
        }
        else
        {
            theText.text = textLines[currentLine];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentLine++;
            }
        }
    }
    public void disableTextBox()
    {
        textBox.SetActive(false);
        isActive = true;
    }
    public void enableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = theText.text.Split('\n');
        }
    }
}

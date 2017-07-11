using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateText : MonoBehaviour {
    public TextAsset theText;
    public TextBoxManager textBox;

    public int startLine;
    public int endLine;
    public bool destroyWhenActivated;

    public int secondsToDestroy;
    // Use this for initialization
    void Start () {
        textBox = FindObjectOfType<TextBoxManager>();
       // StartCoroutine(DestroyObjectAfter15Seconds(secondsToDestroy));
    }
	
	// Update is called once per frame
	void Update () {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (textBox != null)
            {
                textBox.ReloadScript(theText);
                textBox.currentLine = startLine;
                textBox.endLine = endLine;
                textBox.enableTextBox();
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            textBox.disableTextBox();
    }

   /* public IEnumerator DestroyObjectAfter15Seconds(int secondsUntilObjectIsDestroyed)//disabled so player can reaccess tutorial
    {
        Debug.Log("Enter");
        yield return new WaitForSeconds(secondsUntilObjectIsDestroyed);
        if (destroyWhenActivated)
            Destroy(gameObject);
    }*/
}

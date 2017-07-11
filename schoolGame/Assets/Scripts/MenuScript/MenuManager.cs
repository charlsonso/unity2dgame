using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

	// Use this for initialization
	public void ToGame()
    {
        SceneManager.LoadScene("LevelOne");
    }
}

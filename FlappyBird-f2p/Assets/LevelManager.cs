using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private void Awake() {
        LevelManager tempLM = FindObjectOfType<LevelManager>();
        if (tempLM != null && tempLM != this) {
            Destroy(tempLM.gameObject);
        }
    }



    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this);		
	}
	
    public void LoadLevel(string LevelName) {
        Application.LoadLevel(LevelName);
    }
	// Update is called once per frame
    public void LoadNextLevel() {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    public void QuitGame() {
        Application.Quit();
    }
}

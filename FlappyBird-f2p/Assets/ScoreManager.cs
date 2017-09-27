using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

    [SerializeField] private Text score;
    [SerializeField] private FlappyPlayer player;

    private Vector3 defaultPosition;
	// Use this for initialization
	void Start () {
        defaultPosition = score.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = player.points.ToString();
        if (player.IsDead()) {
            score.rectTransform.localPosition = new Vector3(0f, 0f, 0f);
 
        }
	}
}

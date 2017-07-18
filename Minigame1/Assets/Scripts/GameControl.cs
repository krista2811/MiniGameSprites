using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	public GameObject gameOver1Text;
    public GameObject gameOver2Text;
	public float scrollSpeed = -1.5f;
	public bool game1Over = false;
    public bool game2Over = false;
    public bool isDash = false;
	public Text score1Text;
    public Text score2Text;
    public GameObject black1;
    public GameObject black2;
    public GameObject StartScene;
	public static GameControl instance;

	private int score1 = 0;
    private int score2 = 0;
	// Use this for initialization
	void Awake () {
		//no gamecontrol found
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}
	}

    private void Start()
    {
        StartScene.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
		if (game1Over == true && Input.GetMouseButtonDown (0) && game2Over == true) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
        if (Input.anyKey)
        {
            StartScene.SetActive(false);
        }
    }
	/**
	 * whenever the bird is scored
	 */
	public void Bird1Scored() {
		if (game1Over) {
			return;
		}
		score1++;
		score1Text.text = "Score: " + score1.ToString ();
        score2Text.text = "Score: " + score2.ToString();
    }

    public void Bird2Scored() {
        if(game2Over)
        {
            return;
        }
        score2++;
        score1Text.text = "Score: " + score1.ToString();
        score2Text.text = "Score: " + score2.ToString();
    }
	public void Bird1Died() {
		gameOver1Text.SetActive (true);
        black1.SetActive(true);
		game1Over = true;
	}
    public void Bird2Died()
    {
        gameOver2Text.SetActive(true);
        black2.SetActive(true);
        game2Over = true;
    }
}

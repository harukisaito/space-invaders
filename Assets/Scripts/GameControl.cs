using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;

	[SerializeField]
	private GameObject ship;

	[SerializeField]
	private int difficulty;

	[SerializeField]
	private  int playerLifes;

	[SerializeField]
	private GameObject firstShip;

	[SerializeField]
	private GameObject secondShip;

	[SerializeField]
	private GameObject thirdShip;

	[SerializeField]
	private EnemySpawn invaders;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text gameOverText;

	[SerializeField]
	private Image gameOverBackground;	

	private bool shipDestroyed;
    private float timer;
	private int score;

	private GameObject shipInstance;
	private Vector3 shipPoolPos = new Vector3(-10, -10);
	private Vector3 shipStartPos = new Vector3(0, -4.5f);
	private GameObject[] enemyCols;

	public int PlayerLifes{
		get { return playerLifes; }
		set { playerLifes = value; }
	}

	public bool ShipDestroyed{
		get { return shipDestroyed; }
		set { shipDestroyed = value; }
	}

	public int Score{
		get { return score; }
		set { score = value; }
	}

	public GameObject ShipInstance{
		get { return shipInstance; }
		set { shipInstance = value; }
	}
	public Vector3 ShipPoolPos
	{
		get {return shipPoolPos;}
		set {shipPoolPos = value;}
	}

	public Vector3 ShipStartPos
	{
		get {return shipStartPos;}
		set {shipStartPos = value;} 
	}

    public GameObject[] EnemyCols
	{
		get { return enemyCols;}
		set { enemyCols = value;}
	}

	// Use this for initialization

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start ()
	{
		shipInstance = Instantiate(ship);
		CreateCols(difficulty);
		invaders.SpawnEnemies(difficulty);
	}

    private void CreateCols(int difficulty)
    {
		enemyCols = new GameObject[difficulty];
		for (int i = 0; i < difficulty; i++)
		{
			GameObject c = new GameObject("Col" + i + 1);
			enemyCols[i] = c;
			c.transform.parent = GameObject.Find("Enemies").transform;
		}
    }

    void Update ()
	{
		timer += Time.deltaTime;
		if(timer > 1.0f)
		{
			GameObject selectedCol = enemyCols[UnityEngine.Random.Range(0, enemyCols.Length)];
			if(selectedCol.transform.childCount > 0)
			{
				selectedCol.transform.GetChild(0).GetComponent<EnemyFire>().Fire();
				timer = 0;
			}
		}

		if(shipInstance.transform.position == shipPoolPos && shipDestroyed == false)
		{
			playerLifes -= 1;
			shipDestroyed = true;
		}
		if(playerLifes > 0 && shipInstance.transform.position != shipPoolPos)
		{
			ShipDestroyed = false;
		}
		if(playerLifes == 2)
		{
			firstShip.SetActive(false);
		}
		if(playerLifes == 1)
		{
			secondShip.SetActive(false);
		}
		if (playerLifes == 0)
		{
			thirdShip.SetActive(false);
			Destroy(shipInstance);	
			SetGameOverScreen();
			Invoke("BackToMenu", 2.0f);
		}
		SetScoreText();
	}

	void BacktoMenu()
	{
		SceneManager.LoadScene(0);
	}

	private void SetScoreText()
	{
		scoreText.text = "SCORE: " + score;
	}

	private void SetGameOverScreen()
	{
		gameOverText.text = "GAME OVER";
		gameOverBackground.rectTransform.sizeDelta = new Vector2(100, 50);
	}
}	

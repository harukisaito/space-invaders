using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;

	[SerializeField]
	private GameObject ship;

	[SerializeField]
	private GameObject redInvader;

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
	private EnemyMovement enemyMovement;

	[SerializeField]
	private Text scoreText;

	[SerializeField]
	private Text gameOverText;

	[SerializeField]
	private Image gameOverBackground;	

	private bool shipDestroyed;
    private float timer;
	private float redTimer;
	private int score;
	private int invaderCount;

	private GameObject shipInstance;
	private Vector3 shipPoolPos = new Vector3(-10, -10);
	private Vector3 shipStartPos = new Vector3(0, -4.5f);
	private List<GameObject> enemyCols;
	private List<GameObject> invaderList = new List<GameObject>();

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
	public int InvaderCount
	{
		get { return invaderCount;}
		set { invaderCount = value;}
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

    public List<GameObject> EnemyCols
	{
		get { return enemyCols;}
		set { enemyCols = value;}
	}

	public List<GameObject> InvaderList
	{
		get { return invaderList;}
		set { invaderList = value;}
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
		invaderCount = invaderList.Count;
	}

    private void CreateCols(int colCount)
    {
		enemyCols = new List<GameObject>();
		for (int i = 0; i < colCount; i++)
		{
			GameObject c = new GameObject("Col" + i);
			enemyCols.Add(c);
			c.transform.parent = GameObject.Find("Enemies").transform;
		}
    }

    void Update ()
	{
		timer += Time.deltaTime;
		redTimer += Time.deltaTime;
		RandomEnemyFire();
		DeleteEmptyCols();
		ChangeInvaderSpeed(invaderCount);
		InstantiateRedInvader();
		ManagePlayerLifes();
		SetScoreText();
	}

	void BackToMenu()
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

	private void ChangeInvaderSpeed(float p)
	{
		p /= 50;
		if(p < 0.5f)
		{
			enemyMovement.MovementSpeed = 0.5f * (float)(1 - Math.Sqrt(1 - 4 * (p * p)));
		}
		else
		{
			enemyMovement.MovementSpeed =  0.5f * (float)(Math.Sqrt(-((2 * p) - 3) * ((2 * p) - 1)) + 1);
		}
	}

	private void ManagePlayerLifes()
	{
		if(playerLifes > 0 && shipInstance.transform.position == shipPoolPos && shipDestroyed == false)
		{
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
	}

	private void RandomEnemyFire()
	{
		if(timer > 1.0f)
		{
			GameObject selectedCol = enemyCols[UnityEngine.Random.Range(0, enemyCols.Count)];
			if(selectedCol.transform.childCount > 0)
			{
				selectedCol.transform.GetChild(0).GetComponent<EnemyFire>().Fire();
				timer = 0;
			}
		}
	}

	private void InstantiateRedInvader()
	{
		if(redTimer >= 15)
		{
			Instantiate(redInvader);
			redTimer = 0;
		}
	}

	private void DeleteEmptyCols()
	{
		for(int i = 0; i < enemyCols.Count; i++)
		{
			if(enemyCols[i].transform.childCount == 0)
			{
				Destroy(enemyCols[i]);
				enemyCols.RemoveAt(i);
			}
		}
	}
}	

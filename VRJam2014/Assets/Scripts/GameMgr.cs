using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMgr : MonoBehaviour {

	public static GameMgr Instance { get; private set; }

	int remainingPointBlockCount = 0;

	public GameObject physicsScene;
	public GameObject podiumRoot;
	public float sceneScale = .25f;

	public int blocksOnGround = 0;
	public int totalNumBlocks = 0;

	public int blocksToWin = 100;

	public int totalNumShotsAvailable = 3;
	public int numShotsTaken = 0;

	public GUIText goalText;
	public GUIText blockText;
	public GUIText shotsText;
	public GUIText winText;
	public GUITexture winBkg;

	public AudioClip[] blockSFX;

	bool canPlaySFX;
	float sfxTimer;

	bool didWin;

	void Awake()
	{
		Instance = this;

		physicsScene.transform.position = podiumRoot.transform.position;
		physicsScene.transform.localScale = new Vector3(sceneScale, sceneScale, sceneScale);
	}

	// Use this for initialization
	void Start () {
		goalText.text = "Knock down " + blocksToWin;
		blockText.text = blocksOnGround + " blocks";
		shotsText.text = GetRemainingShots () + " shots";
		winText.text = "";
		winBkg.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button3)) 
		{
			Application.LoadLevel (Application.loadedLevel);
		}
		if (didWin) 
		{
			if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button7))
			{
				Application.LoadLevel (Application.loadedLevel+1);
			}
		}
		if (!canPlaySFX) 
		{
			sfxTimer -= Time.deltaTime;
			if (sfxTimer <= 0)
				canPlaySFX = true;
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button8)) {
			Application.LoadLevel(Application.loadedLevel-1);
		}
		if (Input.GetKeyDown (KeyCode.Joystick1Button9)) {
			Application.LoadLevel(Application.loadedLevel+1);
		}
	}
	
	public void RegisterSpecialBlock(SpecialBlock bl)
	{
		if (bl.behavior == SpecialBlock.Behavior.kPoints)
			++remainingPointBlockCount;
	}
	
	public void RegisterBlock(Block bl)
	{
		++totalNumBlocks;
	}

	public void BlockHitGround(Block bl)
	{
		++blocksOnGround;
		if (blocksOnGround >= blocksToWin && GetRemainingShots() >= 0) 
		{
			didWin = true;
			winText.text = "You win!  Press start to continue!";
			winBkg.enabled = true;
			//Application.LoadLevel (Application.loadedLevel+1);
		}
		blockText.text = blocksOnGround + " blocks";
	}

	public void PointBlockHit(SpecialBlock bl)
	{
		--remainingPointBlockCount;
		/*if (remainingPointBlockCount <= 0) 
		{
			Application.LoadLevel (Application.loadedLevel+1);
		}*/
	}

	public void LoseBlockHit(SpecialBlock bl)
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public int GetRemainingShots()
	{
		return totalNumShotsAvailable - numShotsTaken;
	}

	public void TookShot()
	{
		++numShotsTaken;
		int x = GetRemainingShots () > 0 ? GetRemainingShots () : 0;
		shotsText.text = x + " shots";
	}

	public AudioClip GetBlockSFX()
	{
		if (canPlaySFX) {
			canPlaySFX = false;
			sfxTimer = .25f;
						return blockSFX [Random.Range (0, blockSFX.Length)];
				}
				else
						return null;
	}
}

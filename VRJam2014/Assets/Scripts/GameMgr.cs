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

	void Awake()
	{
		Instance = this;

		physicsScene.transform.position = podiumRoot.transform.position;
		physicsScene.transform.localScale = new Vector3(sceneScale, sceneScale, sceneScale);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown(KeyCode.Joystick1Button3)) 
		{
			Application.LoadLevel (Application.loadedLevel);
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
		if (blocksOnGround >= blocksToWin) 
		{
			Application.LoadLevel (Application.loadedLevel+1);
		}
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
	}
}

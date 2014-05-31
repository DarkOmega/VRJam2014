﻿using UnityEngine;
using System.Collections;

public class GameMgr : MonoBehaviour {

	public static GameMgr Instance { get; private set; }

	int remainingPointBlockCount = 0;

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) 
		{
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	public void RegisterSpecialBlock(SpecialBlock bl)
	{
		if (bl.behavior == SpecialBlock.Behavior.kPoints)
			++remainingPointBlockCount;
	}

	public void PointBlockHit(SpecialBlock bl)
	{
		--remainingPointBlockCount;
		if (remainingPointBlockCount <= 0) 
		{
			Application.LoadLevel (Application.loadedLevel+1);
		}
	}

	public void LoseBlockHit(SpecialBlock bl)
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Currancy;
	public int startCurrancy = 400;

	public static int Lives;
	public int startLives = 20;

	public static int Rounds;

	void Start ()
	{
		Currancy = startCurrancy;
		Lives = startLives;

		Rounds = 0;
	}
}


using UnityEngine;
public class User {

	private int _coins = 10;

	public int Coins{
		get { return _coins; }
		set { _coins = value; Debug.Log("Coins: " + _coins); }
	}

}

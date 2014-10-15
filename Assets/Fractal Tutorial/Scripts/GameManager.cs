using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Fractal fractalPrefab;

	Fractal fractalInstance;

	// Use this for initialization
	void Start () {
		BeginGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			StopAllCoroutines ();
			Destroy(fractalInstance.gameObject);
			BeginGame ();
		}
	}

	void BeginGame(){
		fractalInstance = Instantiate (fractalPrefab) as Fractal;
	}

	void RestartGame () {
		Destroy (fractalInstance);
		BeginGame ();
	}
}

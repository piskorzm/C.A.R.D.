using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	public GameObject CardHolder;

	void Start () {
		//Destroy all active cards
		for(int i = 0; i < CardHolder.transform.childCount; i++)
		{
			Destroy(CardHolder.transform.GetChild(i).gameObject);
		}

		//Repopulate them
		for(int i = 0; i < 5; i++)
		{
			CardObject newCard = Instantiate(Resources.Load<GameObject>("Card"), new Vector3(-14 + (i * 7), 0, 0), Quaternion.identity).GetComponent<CardObject>();
			newCard.InitialiseCard(CardManager.Controller.GetRandomCard());
			newCard.transform.parent = CardHolder.transform;
		}
	}

	private void Update()
	{
		//TEMP - Refresh hand with random cards
		if(Input.GetKeyDown(KeyCode.P))
		{
			Start();
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

	public GameObject CardHolder;

	public CardObject SelectedCard;

	private bool dragMode = false;

	void Start()
	{
		//Destroy all active cards
		for (int i = 0; i < CardHolder.transform.childCount; i++)
		{
			Destroy(CardHolder.transform.GetChild(i).gameObject);
		}

		//Repopulate them
		for (int i = 0; i < 5; i++)
		{
			CardObject newCard = Instantiate(Resources.Load<GameObject>("Card"), new Vector3(-14 + (i * 7), 0, 0), Quaternion.identity).GetComponent<CardObject>();
			newCard.InitialiseCard(CardManager.Controller.GetRandomCard());
			newCard.transform.parent = CardHolder.transform;
		}
	}

	private void Update()
	{
		//TEMP - Refresh hand with random cards
		if (Input.GetKeyDown(KeyCode.P))
		{
			Start();
		}

		Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		//D
		if (Input.GetMouseButtonDown(0) && SelectedCard != null)
		{
			dragMode = true;
		}

		//D
		if (dragMode)
		{
			Vector3 newCardPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			newCardPos.y = 0;
			SelectedCard.transform.position = newCardPos;

			if (Input.GetMouseButtonUp(0) || !Input.GetMouseButton(0))
			{
				dragMode = false;
			}
		}
		else
		{
			//Emit a ray from the camera using the mouse position
			if (Physics.Raycast(screenRay, out hit))
			{
				//Attempt to get the CardObject componenet of the hit object, if there is one
				CardObject hitCard = hit.transform.GetComponent<CardObject>();

				//Check if the ray is hitting a CardObject
				if (hitCard != null)
				{
					//Reset old selected card if it is a different card
					if (SelectedCard != null && SelectedCard != hitCard)
					{
						iTween.MoveTo(SelectedCard.gameObject, SelectedCard.OriginPosition, 0.5f);
						iTween.ScaleTo(SelectedCard.gameObject, SelectedCard.OriginScale, 0.5f);
					}

					//Select the new card
					SelectedCard = hitCard;
					iTween.MoveTo(SelectedCard.gameObject, SelectedCard.OriginPosition + new Vector3(0, 5, 0), 0.5f);
					iTween.ScaleTo(SelectedCard.gameObject, SelectedCard.OriginScale * 2, 0.5f);
				}
			}
			else
			{
				//Reset old selected card if there is one
				if (SelectedCard != null)
				{
					iTween.MoveTo(SelectedCard.gameObject, SelectedCard.OriginPosition, 0.5f);
					iTween.ScaleTo(SelectedCard.gameObject, SelectedCard.OriginScale, 0.5f);
					SelectedCard = null;
				}
			}
		}
	}
}

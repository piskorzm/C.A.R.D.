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

		//Enable dragmode if the user has pressed the left mouse button whilst selecting a card
		if (!dragMode && (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && SelectedCard != null)
		{
			dragMode = true;

			//Stop any tweens on the current card
			iTween.Stop(SelectedCard.gameObject);
		}

		//Move selected card towards mouse position if drag mode is enabled
		if (dragMode)
		{
			//Use the mouse position to determine where the card should be
			//TODO: More accurate mouse to world position via ray/plane intersecting
			Vector3 newCardPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 30));
			newCardPos.y = 5;
			SelectedCard.transform.position = Vector3.Lerp(SelectedCard.transform.position, newCardPos, 0.1f);

			//If the user releases the mouse
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

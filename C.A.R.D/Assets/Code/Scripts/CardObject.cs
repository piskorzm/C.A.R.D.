using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardObject : MonoBehaviour {

	public Card card;

	public TextMeshPro NameText;
    public TextMeshPro DescriptionText;
    public TextMeshPro CostText;
	public TextMeshPro HealthText;
	public TextMeshPro AttackText;

    public const int IMAGE_INDEX = 0;
    public const int CARDBACK_INDEX = 1;

	void Start () {
		//TEMP - Load from dictionary later
		InitialiseCard(new SpellCard(1, "Small Rock", Rarity.LEGENDARY, "It's a small rock!", 0, "SmallRock", new Effect(TargetType.TARGET, 1)));
	}

	void InitialiseCard(Card c)
	{
		//Set card
		card = c;
		
		//Assign card art
		Material imageMaterial = new Material(Shader.Find("Standard"));
		imageMaterial.mainTexture = (Texture2D)Resources.Load("CardImages/" + card.ImagePath);
		imageMaterial.name = "Art Material";
		transform.Find("Art").GetComponent<MeshRenderer>().material = imageMaterial;

		//Get gem object and change its color
		transform.Find("Gems").GetComponent<MeshRenderer>().material.color = GetRarityColor(card);

		//Set card text
		NameText.text = card.Name;
        DescriptionText.text = card.Description;
        CostText.text = card.Cost.ToString();

        if(card.GetType() == typeof(MinionCard))
        {
            AttackText.text = ((MinionCard)card).Attack.ToString();
            HealthText.text = ((MinionCard)card).Health.ToString();
        }
        else
        {
            AttackText.text = "";
            HealthText.text = "";
        }
	}

	private Color GetRarityColor(Card c)
	{
		switch(c.CardRarity)
		{
			case Rarity.COMMON:
				return Color.white;
			case Rarity.UNCOMMON:
				return Color.green;
			case Rarity.RARE:
				return Color.blue;
			case Rarity.EPIC:
				return Color.magenta;
			case Rarity.LEGENDARY:
				return new Color(1, 0.6f, 0);
		}

		//Shouldn't happen
		return Color.black;
	}
}

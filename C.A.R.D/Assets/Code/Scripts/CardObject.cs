using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour {

    public const int IMAGE_INDEX = 0;
    public const int CARDBACK_INDEX = 1;

	void Start () {
        Material imageMaterial = new Material(Shader.Find("Standard"));
        imageMaterial.mainTexture = (Texture2D)Resources.Load("CardImages/AngryCat");
        imageMaterial.name = "ImageMat";
        GetComponent<MeshRenderer>().material = imageMaterial;
	}
}

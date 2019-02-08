using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
        //the code for the number of baskets
        basketList = new List<GameObject>();
		for (int i=0; i<numBaskets; i++) {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero; //variable pos set to 0,0,0
            pos.y = basketBottomY + (basketSpacingY * i); //sets basket to 0, -14, 0, then the next one to 0, -12, 0, then 0, -10, 0
            tBasketGO.transform.position = pos; 
            basketList.Add(tBasketGO); //puts basket in list
        }
    }
   public void AppleDestroyed() {
        // Destroy all of the falling apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject tBasketGo = basketList[basketIndex];
        //Remove the Basket from the list and destroy the GameObject
        basketList.RemoveAt( basketIndex );
        Destroy(tBasketGo);

        //If there are no Baskets left, restart the game
        if (basketList.Count == 0) {
            SceneManager.LoadScene("Apple Picker Project");
        }
    }

}

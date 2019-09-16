using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMain : MonoBehaviour {

    public float speed;
    public bool buildMode;
    public BuilderTool builderTool;
    public GameObject builderGameObject;
    public int food;
    public int gold;
    public int timber;
    public Text foodText;
    public Text goldText;
    public Text timberText;
    public Camera gameCamera;
    private Vector3 worldPoint;

	// Use this for initialization
	void Start () {
        buildMode = false;
        builderGameObject.SetActive(false);

        // Start of game
        food = 100;
        gold = 100;
        timber = 100;
        foodText.text = food.ToString();
        goldText.text = gold.ToString();
        timberText.text = timber.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        // Return what current building is
        if (Input.GetMouseButtonDown(0) && buildMode) {
            switch(builderTool.currentBuildingCode) {
                case 0:
                    if (timber >=10) {
                        timber -= 10;
                    }

                    break;
                case 1:
                    if (timber >= 10) {
                        timber -= 10;
                    }
                    break;
                default:
                    break;

            }
            foodText.text = food.ToString();
            goldText.text = gold.ToString();
            timberText.text = timber.ToString();
        }

        // Build
        if (Input.GetKeyDown(KeyCode.B)) {
            // Build Mode Activated!
            if (!buildMode) {
                buildMode = true;
                builderTool.buildMode = true;
                builderGameObject.SetActive(true);
                builderTool.buildable = true;
                Debug.Log("Build Mode Activated!");
            }
            // Build Mode Deactivated!
            else {
                buildMode = false;
                builderTool.buildMode = false;
                builderGameObject.SetActive(false);
                //builderTool.buildable = true;
                Debug.Log("Build Mode Deactivated!");
            }
        }

        //Movement
        if (!buildMode) {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
        }
        else {
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            builderGameObject.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
        }
	}
}

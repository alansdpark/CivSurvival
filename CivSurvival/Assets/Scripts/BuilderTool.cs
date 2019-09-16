using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderTool : MonoBehaviour {

    Material mMaterial;
    public bool buildable;
    public bool buildMode;
    public GameObject currentBuilding;
    public GameObject basicFenceHorizontal;
    public GameObject basicFenceVertical;
    public Material buildableMat;
    public Material notBuildableMat;
    public int currentBuildingCode;
    public PlayerMain playerMain;
    private bool notEnoughResources;

	// Use this for initialization
	void Start () {
        mMaterial = GetComponent<Renderer>().material;
        buildable = true;
        currentBuilding = basicFenceHorizontal;
        currentBuildingCode = 0;
        notEnoughResources = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.buildMode) {
            
            if (Input.GetKeyDown(KeyCode.M)) {
                currentBuilding = basicFenceVertical;
            }
            if (Input.GetKeyDown(KeyCode.N)) {
                currentBuilding = basicFenceHorizontal;
            }

            if (buildable)
            {
                mMaterial.color = buildableMat.color;
                if (Input.GetMouseButtonDown(0)) {
                    switch (currentBuildingCode) {
                        case 0:
                            if (playerMain.timber < 10) {
                                Debug.Log("Not enough timber!");
                                notEnoughResources = true;
                            }
                            break;
                        case 1:
                            if (playerMain.timber < 10) {
                                Debug.Log("Not enough timber!");
                                notEnoughResources = true;
                            }
                            break;
                        default:
                            break;
                    }
                    if (!notEnoughResources) {
                        Instantiate(currentBuilding, this.transform.position, currentBuilding.transform.rotation, null);
                    }
                    notEnoughResources = false;
                    buildable = false;
                }
            }
            else
            {
                mMaterial.color = notBuildableMat.color;
            }
        }
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
	       if (collision.tag.Equals("Buildings"))
	       {
	           buildable = true;
	           return;
	       }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	       if (collision.tag.Equals("Buildings"))
	       {
	           buildable = false;
	           return;
	       }
	}
}

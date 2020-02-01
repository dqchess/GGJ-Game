using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarMap : MonoBehaviour
{
    public ShipController shipController;
    public float ShipPosX;
    public float ShipPosY;
    public GameObject[] RIcon = new GameObject[8];
    public GameObject[] TIcon = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MapUpdate(TIcon,shipController.ResourcesList_Get());
    }
    private void MapUpdate(GameObject[] iconList, List<GameObject> itemList)
    {
        if(iconList!=null&&itemList!=null)
            for (int i = 0; i < iconList.Length; i++)
            {
                if (i < itemList.Count)
                {
                    ShipPosX = itemList.ToArray()[i].transform.position.x - shipController.posX;
                    ShipPosY = itemList.ToArray()[i].transform.position.y - shipController.posZ;
                    ShipPosX = ShipPosX / 300 * 180;
                    ShipPosY = ShipPosY / 300 * 180;
                    iconList[i].transform.position = new Vector3(ShipPosX, ShipPosY, 0);
                }
            }
    }
}

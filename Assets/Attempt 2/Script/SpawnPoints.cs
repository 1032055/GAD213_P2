using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField] GameObject spawnPointPrefab, menuObj;
    List<GameObject> allPoints = new List<GameObject>();
    [SerializeField] int numOfPoints = 16, spacing = 10;
    Vector3 spawnPos = Vector3.zero;
    bool firstRoom = true;
    [SerializeField] RoomGen roomGenScript;

    void Awake()
    {
        SpawnThePoints();
    }

    private void SpawnThePoints()
    {
        bool lastRoomLeft = false,
            lastRoomRight = false;

        for (int i = 0; i < numOfPoints; i++)
        {
            if(firstRoom)
            {
                spawnPos = Vector3.zero;
                firstRoom = false;
                Debug.Log("first room spawned");
            }
            else
            {
                int xOrY = Random.Range(0, 3);
                
                if (xOrY == 1 && !lastRoomRight)
                {
                    //move next room left - X axis Negative
                    spawnPos = new Vector3(spawnPos.x + spacing, spawnPos.y, spawnPos.z);

                    Debug.Log("room spawned Left");
                    lastRoomLeft = true;
                    lastRoomRight = false;
                }
                else if (xOrY == 2 && !lastRoomLeft)
                {
                    //move next room right - X axis Positive
                    spawnPos = new Vector3(spawnPos.x - spacing, spawnPos.y, spawnPos.z);

                    Debug.Log("room spawned Right");
                    lastRoomLeft = false;
                    lastRoomRight = true;
                }
                else
                {
                    //move next room forward - Z axis
                    spawnPos = new Vector3(spawnPos.x, spawnPos.y, spawnPos.z + spacing);

                    Debug.Log("room spawned forward");
                    lastRoomLeft = false;
                    lastRoomRight = false;
                }
            }
            
            //menuObj.transform.position = spawnPos;
            
            GameObject thisPoint = Instantiate(spawnPointPrefab, spawnPos, Quaternion.Euler(0, 0, 0));
            allPoints.Add(thisPoint);
            Debug.Log("point spawned");
        }

        Debug.Log("Starting Room Spawn");
        roomGenScript.roomPosis = allPoints;

        roomGenScript.GenerateRooms();
    }
}

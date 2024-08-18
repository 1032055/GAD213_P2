using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    public List<GameObject> roomPosis = new List<GameObject>();

    [SerializeField] List<GameObject> roomPrefabs = new List<GameObject>(), 
        specialRooms = new List<GameObject>();

    [SerializeField] int lastestStartPos;

    [SerializeField] GameObject endRoom, startRoom;
    bool startSpawned = false, endSpawned = false;

    private void Start()
    {
        //GenerateRooms();
    }

    public void GenerateRooms()
    {
        for(int i = 0; i < roomPosis.Count - 1; i++)
        {
            int num = Random.Range(0, roomPrefabs.Count);
            GameObject theRoom = roomPrefabs[num];

            if (i == lastestStartPos && !startSpawned)
            {
                Instantiate(startRoom, roomPosis[i].transform);
                roomPrefabs.Remove(startRoom);
                startSpawned = true;
            }
            else
            {
                Instantiate(theRoom, roomPosis[i].transform);
            }

            if (theRoom == startRoom)
            {
                roomPrefabs.Remove(startRoom);
                startSpawned = true;
            }

            if (specialRooms.Contains(theRoom))
            {
                roomPrefabs.Remove(theRoom);
            }

            //roomPosis[i].SetActive(false);
        }

        if(!endSpawned)
        {
            Instantiate(endRoom, roomPosis[roomPosis.Count-1].transform);
            roomPrefabs.Remove(endRoom);
            endSpawned = true;
            //roomPosis[roomPosis.Count - 1].SetActive(false);
        }
    }
}

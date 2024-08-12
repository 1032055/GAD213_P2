using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGen : MonoBehaviour
{
    [SerializeField] List<GameObject> roomPosis = new List<GameObject>(), roomPrefabs = new List<GameObject>(), specialRooms = new List<GameObject>();
    [SerializeField] GameObject endRoom, startRoom;
    bool startSpawned, endSpawned;

    private void Start()
    {
        GenerateRooms();
        startSpawned = false;
        endSpawned = false;
    }

    private void GenerateRooms()
    {
        for(int i = 0; i < roomPosis.Count; i++)
        {
            int num = Random.Range(0, roomPrefabs.Count);

            if (i == roomPosis.Count - 2 && !startSpawned)
            {
                Instantiate(startRoom, roomPosis[i].transform);
                roomPrefabs.Remove(startRoom);
                startSpawned = true;
            }
            else if (i == roomPosis.Count - 1 && !endSpawned)
            {
                Instantiate(endRoom, roomPosis[i].transform);
                roomPrefabs.Remove(endRoom);
                endSpawned = true;
            }
            else
            {
                Instantiate(roomPrefabs[num], roomPosis[i].transform);
            }

            if (roomPrefabs[num] == endRoom)
            {
                roomPrefabs.Remove(endRoom);
                endSpawned = true;
            }
            else if (roomPrefabs[num] == startRoom)
            {
                roomPrefabs.Remove(startRoom);
                startSpawned = true;
            }

            if (specialRooms.Contains(roomPrefabs[num]))
            {
                GameObject room = roomPrefabs[num];
                roomPrefabs.Remove(room);
            }
        }
    }
}

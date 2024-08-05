using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    [SerializeField] List<IndvRoom> allRooms = new List<IndvRoom>();
    [SerializeField] Transform nextRoomPos;
    [SerializeField] GameObject father;
    IndvRoom previousRoom, nextRoom;

    private void Start()
    {
        PickRoom();
    }

    public void PickRoom()
    {
        Debug.Log("Selecting Room");
        int num = Random.Range(0, allRooms.Count);
        
        if(allRooms[num] == previousRoom && allRooms.Count >= 3)
        {
            PickRoom();
        }
        else
        {
            nextRoom = allRooms[num];

            Debug.Log("Selected room: " + nextRoom);
            SpawnRoom();
        }
    }

    private void SpawnRoom()
    {
        if (previousRoom)
        {
            IndvRoom newRoom = Instantiate<IndvRoom>(nextRoom, nextRoomPos.position, nextRoomPos.rotation, father.transform);
            Debug.Log("Next room spawned at: " + previousRoom.exitry);
        }
        else
        {
            IndvRoom newRoom = Instantiate<IndvRoom>(nextRoom, nextRoomPos);
            Debug.Log("First Room Spawned");
        }
        nextRoomPos = nextRoom.exitry.transform;
        previousRoom = nextRoom;
    }
}

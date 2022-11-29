using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RoomTemplates : MonoBehaviour
{
    public static bool initRandom = false;

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;

    public GameObject Obj;
    public GameObject ObjFeo;

    int num;

    private void Start()
    {
        Invoke("SpawnObj", 4f);

    }

    void SpawnObj()
    {
        if (!initRandom)
        {
            Random.InitState(4);

            initRandom = true;
        }

        num = Random.Range(1, 4);
        Instantiate(Obj, rooms[rooms.Count - (num)].transform.position, Quaternion.identity);
        //Instantiate(Obj, rooms[rooms.Count - 1 ].transform.position, Quaternion.identity);

        /* for (int i = 1; i<rooms.Count-1; i++)
        {
            Instantiate(ObjFeo, rooms[i].transform.position, Quaternion.identity);
        }
    */
    }
}

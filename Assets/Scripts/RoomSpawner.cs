using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openSide;

    //1 Need Botton 
    //2 Need top        
    //3 Need Left 
    //4 Need Right

    public RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    
    private RoomTemplates GetTemplates()
    {
        if(templates == null)
        {
            templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        }
        return templates;
    }

    void Spawn() 
    {
        if (spawned==false)
        {
            if (openSide == 1)
            {
                //Need Botton
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);

            }
            else if (openSide == 2)
            {
                //Need top
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openSide == 3)
            {
                //Need Left
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openSide == 4)
            {
                //Need Right
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            
            spawned = true;
        }     
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            var roomSpawner = other.GetComponent<RoomSpawner>();
            if (roomSpawner != null && roomSpawner.spawned == false && spawned == false)
            {
                Instantiate(GetTemplates().closedRooms, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true; 
        }

    }
    //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
}

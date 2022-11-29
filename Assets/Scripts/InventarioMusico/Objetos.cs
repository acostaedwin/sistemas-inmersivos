using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public Inventario inventario;

    void Start()
    {
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter: " + other.tag + " - " + other.name);
        if (other.tag == "Player")
        {
            inventario.Cantidad = inventario.Cantidad +1;
            Destroy(gameObject);
        }
        
    }

}

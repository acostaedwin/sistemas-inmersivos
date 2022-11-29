using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public int Cantidad = 0;

    public AudioSource tokenCollectedSound;

    GameControllerScript gameControllerScript;

    void Start()
    {
        gameControllerScript =
            GameObject.FindObjectOfType(typeof (GameControllerScript)) as
            GameControllerScript;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NotasMusic"))
        {
            playSound (tokenCollectedSound);
            gameControllerScript.tokensCollected++;
            gameControllerScript.UpdateTokenCounterMusician();
            Destroy(other.gameObject);

            if (gameControllerScript.tokensCollected == Cantidad)
            {
                gameControllerScript.AllTokenCollected();
            }
        }
    }

    private void playSound(AudioSource sound)
    {
        if (sound != null)
        {
            sound.Play();
        }
    }
}

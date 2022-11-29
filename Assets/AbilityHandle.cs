using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandle : MonoBehaviour
{
    GameControllerScript gameControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameControllerScript =
            GameObject.FindObjectOfType(typeof (GameControllerScript)) as
            GameControllerScript;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ability1"))
        {
            gameControllerScript.TurnOffLightsForMusicianTrigger();
        }
    }
}

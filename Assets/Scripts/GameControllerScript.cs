using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    GameObject panelUIMusico;

    GameObject panelUIDemonio;

    public bool isThisPlayerMusician;

    public int tokensCollected;

    // Start is called before the first frame update
    void Start()
    {
        panelUIMusico = GameObject.Find("PanelUIMusico");
        panelUIDemonio = GameObject.Find("PanelUIDemonio");

        StartCoroutine(TurnOffLightsForMusician());
        tokensCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TurnOffLightsForMusician()
    {
        for (int i = 0; i < 3; i++)
        {
            ViewOffForMusician();
            yield return new WaitForSeconds(0.25f);
            ViewOnForMusician();
            yield return new WaitForSeconds(0.5f);
        }

        // apagamos por 5 segundos
        ViewOffForMusician();
        yield return new WaitForSeconds(5f);
        ViewOnForMusician();
    }

    private void ViewOnForMusician()
    {
        ChangeAlpha(panelUIMusico.GetComponent<Image>(), 0f);
    }

    private void ViewOffForMusician()
    {
        ChangeAlpha(panelUIMusico.GetComponent<Image>(), 1f);
    }

    private void ChangeAlpha(Image panelImageUI, float alpha)
    {
        panelImageUI.color =
            new Color(panelImageUI.color.r,
                panelImageUI.color.g,
                panelImageUI.color.b,
                alpha);
    }

    public void UpdateTokenCounterMusician()
    {
        GameObject.Find("MusicoUIText").GetComponent<TextMeshProUGUI>().text =
            tokensCollected + "/4 Notas";
    }

    public void AllTokenCollected()
    {
        if (isThisPlayerMusician)
        {
            GameObject
                .Find("MusicoUITextWon")
                .GetComponent<TextMeshProUGUI>()
                .text = "¡Ganaste!";
            GameObject
                .Find("DemonUITextWon")
                .GetComponent<TextMeshProUGUI>()
                .text = "¡Ganaste!";
        }
        else
        {
            GameObject
                .Find("DemonUITextWon")
                .GetComponent<TextMeshProUGUI>()
                .text = "¡Ganaste!";
            GameObject
                .Find("MusicoUITextWon")
                .GetComponent<TextMeshProUGUI>()
                .text = "¡Ganaste!";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbility : MonoBehaviour
{
    // GameObject PlayerPanel1;
    Image playerPanel1Image;

    GameObject TextAbility1;

    int secondsOfAbility1 = 10;

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPanel1 = GameObject.Find("PlayerPanel1");
        playerPanel1Image =
            GameObject.Find("PlayerPanel1").GetComponent<Image>();
        TextAbility1 = GameObject.Find("TextAbility1");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartAbility(1);
        }
    }

    private void StartAbility(int ability)
    {
        StartCoroutine(StartAbility1());
    }

    private void ChangeAlpha(float alpha)
    {
        playerPanel1Image.color =
            new Color(playerPanel1Image.color.r,
                playerPanel1Image.color.g,
                playerPanel1Image.color.b,
                alpha);
    }

    private void ViewOn()
    {
        ChangeAlpha(0f);
    }

    private void ViewOff()
    {
        ChangeAlpha(1f);
    }

    IEnumerator StartAbility1()
    {
        for (int i = 0; i < 3; i++)
        {
            ViewOff();
            yield return new WaitForSeconds(0.25f);
            ViewOn();
            yield return new WaitForSeconds(0.5f);
        }

        // apagamos por 5 segundos
        ViewOff();
        yield return new WaitForSeconds(5f);
        ViewOn();
        RestartAbility1();
    }

    private void RestartAbility1()
    {
        StartCoroutine(CounterDownAbility1());
    }

    IEnumerator CounterDownAbility1()
    {
        TextAbility1.GetComponent<TextMeshProUGUI>().text =
            secondsOfAbility1.ToString();
        secondsOfAbility1 = secondsOfAbility1 - 1;
        yield return new WaitForSeconds(1f);
        if (secondsOfAbility1 > 0)
            StartCoroutine(CounterDownAbility1());
        else
        {
            secondsOfAbility1 = 10;
            TextAbility1.GetComponent<TextMeshProUGUI>().text = "*";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour
{

    public static int IS_MAIN = 1;
    public static int IS_LEVELS = 2;
    public static int IS_GAMEOVER = 3;

    public int state = ButtonPress.IS_MAIN;

    public GameObject play;
    public GameObject lvl1;
    public GameObject lvl2;
    public GameObject lvl3;
    public GameObject replay;

    public GameObject playB;
    public GameObject lvl1B;
    public GameObject lvl2B;
    public GameObject lvl3B;
    public GameObject replayB;

    public GameObject scoreText;

    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        if (Params.score != 0)
        {
            Text text = scoreText.GetComponent<Text>();
            text.text = "Score: " + Params.score.ToString();
        } else
        {
            Text text = scoreText.GetComponent<Text>();
            text.text = "The Game";
        }

        if (Params.isGO)
        {
            SetState(IS_GAMEOVER);
            return;
        }

        lvl1.SetActive(false);
        lvl2.SetActive(false);
        lvl3.SetActive(false);
        replay.SetActive(false);

        lvl1B.SetActive(false);
        lvl2B.SetActive(false);
        lvl3B.SetActive(false);
        replayB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            RaycastHit ray;
            if (Physics.Raycast(gun.transform.position, gun.transform.forward, out ray))
            {
                Debug.Log(ray.collider.gameObject.tag);
                if (ray.collider != null && ray.collider.gameObject.name == "BtnPlay")
                {
                    play.GetComponent<Button>().onClick.Invoke();
                    SetState(ButtonPress.IS_LEVELS);
                }

                if (ray.collider != null && ray.collider.gameObject.name == "BtnLvl1")
                {
                    lvl1.GetComponent<Button>().onClick.Invoke();
                    //SetState(ButtonPress.IS_LEVELS);
                }
                if (ray.collider != null && ray.collider.gameObject.name == "BtnLvl2")
                {
                    lvl2.GetComponent<Button>().onClick.Invoke();
                    //SetState(ButtonPress.IS_LEVELS);
                }
                if (ray.collider != null && ray.collider.gameObject.name == "BtnLvl3")
                {
                    lvl3.GetComponent<Button>().onClick.Invoke();
                    //SetState(ButtonPress.IS_LEVELS);
                }

                if (ray.collider != null && ray.collider.gameObject.name == "BtnReplay")
                {
                    replay.GetComponent<Button>().onClick.Invoke();
                    SetState(ButtonPress.IS_MAIN);
                }
            }
        }
    }

    public void SetState(int s)
    {
        state = s;

        if (s == ButtonPress.IS_MAIN)
        {
            play.SetActive(true);
            lvl1.SetActive(false);
            lvl2.SetActive(false);
            lvl3.SetActive(false);
            replay.SetActive(false);

            playB.SetActive(true);
            lvl1B.SetActive(false);
            lvl2B.SetActive(false);
            lvl3B.SetActive(false);
            replayB.SetActive(false);
        } else if (s == ButtonPress.IS_LEVELS)
        {
            play.SetActive(false);
            lvl1.SetActive(true);
            lvl2.SetActive(true);
            lvl3.SetActive(true);
            replay.SetActive(false);

            playB.SetActive(false);
            lvl1B.SetActive(true);
            lvl2B.SetActive(true);
            lvl3B.SetActive(true);
            replayB.SetActive(false);
        }
        else if (s == ButtonPress.IS_GAMEOVER)
        {
            play.SetActive(false);
            lvl1.SetActive(false);
            lvl2.SetActive(false);
            lvl3.SetActive(false);
            replay.SetActive(true);

            playB.SetActive(false);
            lvl1B.SetActive(false);
            lvl2B.SetActive(false);
            lvl3B.SetActive(false);
            replayB.SetActive(true);
        }
    }
}

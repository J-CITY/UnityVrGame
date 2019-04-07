using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{

    public float timer = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        GameObject _timer = GameObject.Find("TimerUi");
        if (_timer != null)
        {
            Text text = _timer.GetComponent<Text>();
            text.text = "Timer: " + timer.ToString("n2") + " Score: " + Params.score.ToString();

        }

        if (timer < 0)
        {
            Params.isGO = true;
            SceneManager.LoadScene("Menu");
        }
    }
}

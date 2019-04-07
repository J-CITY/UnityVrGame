using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Button play;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SelectLevel1()
    {
        Params.level = 1;
        //play.GetComponent<Button>().GetComponentInChildren<Text>().text = "testing";
        SceneManager.LoadScene("SampleScene");
    }
    public void SelectLevel2()
    {
        Params.level = 2;
        //play.GetComponent<Button>().GetComponentInChildren<Text>().text = "testing";
        SceneManager.LoadScene("SampleScene");
    }
    public void SelectLevel3()
    {
        Params.level = 3;
        //play.GetComponent<Button>().GetComponentInChildren<Text>().text = "testing";
        SceneManager.LoadScene("SampleScene");
    }
}

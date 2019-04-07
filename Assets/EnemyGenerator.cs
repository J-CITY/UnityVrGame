using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;

    private int lvl = 1;

    private float timerGen = 5f;
    private float timerGenDef = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Params.score = 0;
        lvl = Params.level;
        if (lvl == 2)
        {
            timerGen = 3f;
            timerGenDef = timerGen;
        } else if (lvl == 3)
        {
            timerGen = 1f;

            timerGenDef = timerGen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerGen -= Time.deltaTime;
        if (timerGen > 0)
        {
            return;
        }

        timerGen = timerGenDef;

        var r = Random.Range(0.0f, 1.0f);
        var alpha = Random.Range(0.0f, 6.28f);
        var radius = Random.Range(3.0f, 7.0f);
        float lvlR = 0.3f;
        if (lvl == 1)
        {
            lvlR = 0.3f;
        } else if (lvl == 3)
        {
            lvlR = 0.5f;
        } else if (lvl == 3)
        {
            lvlR = 0.7f;
        }

        GameObject enemy = null;
        if (r > lvlR)
        {
            enemy = Instantiate(enemyPrefab1);
        }
        else
        {
            enemy = Instantiate(enemyPrefab2);
        }
        enemy.transform.position = new Vector3(radius * Mathf.Cos(alpha), 0f, radius * Mathf.Sin(alpha));
    }
}

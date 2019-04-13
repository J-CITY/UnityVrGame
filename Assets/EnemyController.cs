using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator anim;

    public GameObject target;

    public float speed = 0.001f;
    public string walk = "Walk";
    public string attack = "Attack01";
    public string die = "Die";
    public int health = 1;

    bool isDaing = false;
    bool isAttak = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger(walk);
        anim.Play(walk);
        Debug.Log("WALK");

        target = GameObject.Find("SciFiHandGun");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDaing)
        {
            daing();
            return;
        }

        if (isAttak)
        {
            return;
        }

        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist < 1f && !isAttak)
        {
            isAttak = true;
            anim.SetTrigger(attack);
            anim.Play(attack);
            Debug.Log("ATTACK");
            return;
        }


        transform.LookAt(target.transform.position);
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            health -= 1;
            if (health <= 0 && !isDaing)
            {
                Params.score += 1;
                anim.SetTrigger(die);
                anim.Play(die);
                Debug.Log("DIE");
                isDaing = true;
            }
            
        }
    }

    float daingTimer = 0f;
    float daingTime = 10f;
    void daing()
    {
        daingTimer += Time.deltaTime;
        if (daingTimer >= daingTime)
        {
            Destroy(this.gameObject);
            //Params.score += 1;
        }
    }
}

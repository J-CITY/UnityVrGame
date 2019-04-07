using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    
    public GameObject bulletPrefab;
    public GameObject gun;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            audioSource.Play();
            shot();
        }
    }

    void shot()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = gun.transform.position + gun.transform.forward;
        bullet.transform.forward = gun.transform.forward;

    }
}

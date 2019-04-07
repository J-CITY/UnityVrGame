using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticule : MonoBehaviour
{

    public Pointer pointer;
    public SpriteRenderer cRander;

    public Sprite opensprite;
    public Sprite closesprite;


    public Camera camera = null;


    private void Awake()
    {
        pointer.onPointerUpdate += UpdateSprite;
        camera = Camera.main;
    }

    private void OnDestroy()
    {
        pointer.onPointerUpdate -= UpdateSprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.gameObject.transform);
    }
    private void UpdateSprite(Vector3 point, GameObject hitObj)
    {
        transform.position = point;
        if (hitObj)
        {
            cRander.sprite = closesprite;
        }
        else
        {
            cRander.sprite = opensprite;
        }
    }
}

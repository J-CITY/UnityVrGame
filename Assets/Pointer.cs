using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pointer : MonoBehaviour
{
    public UnityAction<Vector3, GameObject> onPointerUpdate = null;
    private GameObject curObject = null;

    public float distance = 10;
    public LineRenderer lineRenderer = null;
    public LayerMask anymask = 0;
    public LayerMask interactmask = 0;

    private Transform currentOrigin;

    private GameObject UpdatePointerStatus()
    {
        RaycastHit hit = CreateRaycast(interactmask);

        if (hit.collider)
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private void Awake()
    {
        PlayerEvents.onControllerSource += UpdateOrigin;
        PlayerEvents.onTouchDown += ProcessTouchpadDown;
    }

    private void OnDestroy()
    {
        PlayerEvents.onControllerSource -= UpdateOrigin;
        PlayerEvents.onTouchDown -= ProcessTouchpadDown;
    }

    private void UpdateOrigin(OVRInput.Controller controller, GameObject obj)
    {
        currentOrigin = obj.transform;

        if (controller == OVRInput.Controller.Touchpad)
        {
            lineRenderer.enabled = false;
        } else
        {
            lineRenderer.enabled = true;
        }
    }

    private void ProcessTouchpadDown()
    {
        if (!curObject)
        {
            return;
        }

        Interactable interactable = curObject.GetComponent<Interactable>();
        interactable.Pressed();
    }
    // Start is called before the first frame update
    void Start()
    {
        SetLineColor();
    }

    private Vector3 UpdateLine()
    {
        RaycastHit hit = CreateRaycast(anymask);
        Vector3 endPos = currentOrigin.position + (currentOrigin.forward * distance);

        if (hit.collider != null)
        {
            endPos = hit.point;
        }

        lineRenderer.SetPosition(0, currentOrigin.position);

        lineRenderer.SetPosition(1, endPos);


        return endPos;
    }

    private RaycastHit CreateRaycast(int layer)
    {
        RaycastHit hit;

        Ray ray = new Ray(currentOrigin.position, currentOrigin.forward);

        Physics.Raycast(ray, out hit, distance);

        return hit;
    }

    void SetLineColor()
    {
        if (!lineRenderer)
        {
            return;
        }

        Color endColor = Color.white;
        endColor.a = 0.0f;
        lineRenderer.endColor = endColor;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 hitPoint = UpdateLine();

        curObject = UpdatePointerStatus();

        if (onPointerUpdate != null)
        {
            onPointerUpdate(hitPoint, curObject);
        }
    }
}

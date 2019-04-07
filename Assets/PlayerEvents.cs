using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{

    public static UnityAction onTouchUp = null;
    public static UnityAction onTouchDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> onControllerSource = null;


    public GameObject rAnchor;
    public GameObject lAnchor;
    public GameObject hAnchor;

    private Dictionary<OVRInput.Controller, GameObject> controllerSets = null;
    private OVRInput.Controller inputSource = OVRInput.Controller.None;
    private OVRInput.Controller controller = OVRInput.Controller.None;
    private bool inputActive = true;


    private void Awake()
    {
        OVRManager.HMDMounted += playerFound;
        OVRManager.HMDUnmounted += playerLost;

        controllerSets = CreateControllerSets();
    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = controller;

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.RTrackedRemote;
        }

        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
        {
            controllerCheck = OVRInput.Controller.LTrackedRemote;
        }



        controller = UpdateSource(controllerCheck, controller);
    }

    void OnDestroy()
    {
        OVRManager.HMDMounted -= playerFound;
        OVRManager.HMDUnmounted -= playerLost;
    }

    private void playerFound()
    {
        inputActive = true;
    }

    private void playerLost()
    {

        inputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets()
    {
        Dictionary<OVRInput.Controller, GameObject> sets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            { OVRInput.Controller.LTrackedRemote, lAnchor},
            { OVRInput.Controller.RTrackedRemote, rAnchor}
        };

        return sets;

    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller prev)
    {
        if (check == prev)
        {
            return prev;
        }

        GameObject gameObject = null;
        controllerSets.TryGetValue(check, out gameObject);

        if (gameObject == null)
        {
            gameObject = hAnchor;
        }

        if (onControllerSource != null)
        {
            onControllerSource(check, gameObject);
        }



        return check;
    }

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (!inputActive)
        {
            return;
        }

        CheckInputSource();


        Input();
    }

    private void CheckInputSource()
    {
        inputSource = UpdateSource(OVRInput.GetActiveController(), inputSource);


        
    }

    private void Input()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if (onTouchDown != null)
            {
                onTouchDown();
            }
        }

        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            if (onTouchUp != null)
            {
                onTouchUp();
            }
        }
    }
}

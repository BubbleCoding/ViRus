using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{

    #region Events
    public static UnityAction OnTouchpadUp = null;
    public static UnityAction OnTouchpadDown = null;
    public static UnityAction OnTriggerUp = null;
    public static UnityAction OnTriggerDown = null;
    public static UnityAction<OVRInput.Controller, GameObject> OnControllerSource = null;
    #endregion
    #region Anchors
    public GameObject m_LeftAnchor;
    public GameObject m_RightAnchor;
    public GameObject m_HeadAnchor;
    #endregion

    #region Input
    private Dictionary<OVRInput.Controller, GameObject> m_ControllerSets = null;
    private OVRInput.Controller m_InputSource = OVRInput.Controller.None;
    private OVRInput.Controller m_Controller = OVRInput.Controller.None;
    private bool m_InputActive = true;
    #endregion

    private void Awake() {
        OVRManager.HMDMounted += PlayerFound;
        OVRManager.HMDUnmounted += PlayerLost;

        m_ControllerSets = CreateControllerSets();
    }

    private void OnDestroy() {
        OVRManager.HMDMounted -= PlayerFound;
        OVRManager.HMDUnmounted -= PlayerLost;
    }


    // Update is called once per frame
    private void Update()
    {
        // check for active input
        if (!m_InputActive)
            return;
        // check if controller exists
        CheckForController();
        //check for input source
        CheckInputSource();

        //check for actual input
        Input();
    }

    private void CheckForController()
    {
        OVRInput.Controller controllerCheck = m_Controller;

        // Right remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
            controllerCheck = OVRInput.Controller.RTrackedRemote;

        // Left remote
        if (OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.LTrackedRemote;

        // If no controllers, headset
        if (!OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote) && 
            !OVRInput.IsControllerConnected(OVRInput.Controller.LTrackedRemote))
            controllerCheck = OVRInput.Controller.Touchpad;

        //Update
        m_Controller = UpdateSource(controllerCheck, m_Controller);
    }

    private void CheckInputSource()
    {
        //Update
        m_InputSource = UpdateSource(OVRInput.GetActiveController(), m_InputSource);
    }

    private void Input()
    {
        // Touchpad down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)) // Change back to Touchpad after adding trigger part
        {
            if (OnTouchpadDown != null)
                OnTouchpadDown();
        }
        // Touchpad up
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)) // Change back to Touchpad after adding trigger part
        {
            if (OnTouchpadUp != null)
                OnTouchpadUp();
        }
        // Add Trigger down/Trigger up
        // Trigger down
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Change back to Touchpad after adding trigger part
        {
            if (OnTriggerDown != null)
                OnTriggerDown();
        }
        // Trigger up
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)) // Change back to Touchpad after adding trigger part
        {
            if (OnTriggerUp != null)
                OnTriggerUp();
        }
        
    }

    private OVRInput.Controller UpdateSource(OVRInput.Controller check, OVRInput.Controller previous)
        {
        // If values are the same, return
        if (check == previous)
            return previous;

        // Get controlelr object
        GameObject controllerObject = null;
        m_ControllerSets.TryGetValue(check, out controllerObject);

        // If no controller, set to the head
        if (controllerObject == null)
            controllerObject = m_HeadAnchor;

        // Send out event
        if (OnControllerSource != null)
            OnControllerSource(check, controllerObject);

        // Return new value
        return check;
    }

    private void PlayerFound() {
        m_InputActive = true;
    }

    private void PlayerLost() {
        m_InputActive = false;
    }

    private Dictionary<OVRInput.Controller, GameObject> CreateControllerSets() {
        Dictionary<OVRInput.Controller, GameObject> newSets = new Dictionary<OVRInput.Controller, GameObject>()
        {
            {OVRInput.Controller.LTrackedRemote, m_LeftAnchor },
            {OVRInput.Controller.RTrackedRemote, m_RightAnchor },
            {OVRInput.Controller.Touchpad, m_HeadAnchor }
        };
        return newSets;
    }
}


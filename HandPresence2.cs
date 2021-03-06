using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class HandPresence2 : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;
    public GameObject Pistols;
    public static InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    public GameObject ray;

    //Pistol pistol;

    /*private void Awake()
    {
        pistol = GameObject.Find("Pistol27").GetComponent<Pistol>();
    }
    */

    void Start()
    {
        TryInitialize();
    }

    void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if(devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if(prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnedHandModel = Instantiate(handModelPrefab, transform);
        }
       
    }
    

    

    // Update is called once per frame
    void Update()
     {
          if (!targetDevice.isValid)
          {
                TryInitialize();
          }

        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
            ray.gameObject.SetActive(false);
            Pistols.gameObject.SetActive(true);
            //Debug.Log("Pressing primary button");

        }

        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue)
        {
            ray.gameObject.SetActive(true);
            Pistols.gameObject.SetActive(false);
            //Debug.Log("Pressing secondary button");

        }


        /*
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.01F)
        {
            //pistol.Shoot();
        }*/

        /*
            if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            {
                Debug.Log("Pressing Primary Button");
            }


            if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            {
                Debug.Log("Trigger pressed" + triggerValue);
            }

            if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) && primary2DAxisValue != Vector2.zero)
            {
                Debug.Log("Primary Touchpad" + primary2DAxisValue);
            }
        */

        if (showController)
        {
            spawnedHandModel.SetActive(false);
            spawnedController.SetActive(true);
        }
        else
        {
            spawnedHandModel.SetActive(true);
            spawnedController.SetActive(false);
        }

    }
}

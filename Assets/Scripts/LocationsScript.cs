using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsScript : MonoBehaviour
{
    public GameObject Locations;
    public GameObject[] cameras;
    private int currentIndex = 0;
    public GameObject cameraCurrent;
    public void LocationsChangeVisible()
    {
        if(Locations.activeSelf)
        {
            Locations.SetActive(false);
            cameras[currentIndex].SetActive(false);
            cameraCurrent.SetActive(true);
        }
        else
        {
            Locations.SetActive(true);
            cameraCurrent.SetActive(false);
            cameras[currentIndex].SetActive(true);

        }
    }

    public void changeCamera(int index)
    {
        cameras[currentIndex].SetActive(false);
        currentIndex = index;
        cameras[currentIndex].SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

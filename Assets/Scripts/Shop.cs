using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool InShop = false;
    public GameObject[] weapons;
    private int number = 0;
    private bool CanvasIsWork = false;

    public GameObject Next;
    public GameObject Previous;
    public GameObject[] weaponCharacters;

    [SerializeField]
    private GameObject shopRoot;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (InShop)
        {
            shopRoot.SetActive(true);
            weapons[number].SetActive(true);
            weaponCharacters[number].SetActive(true);
            Next.SetActive(true);
            Previous.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CanvasIsWork = true;
           

        }

        if (number < 3 && CanvasIsWork)
        {
            Next.SetActive(true);
        }
        else
        {
            Next.SetActive(false);
        }


        if (number > 0 && CanvasIsWork)
        {
            Previous.SetActive(true);
        }
        else
        {
            Previous.SetActive(false);
        }
        
        if(!InShop)
        {
            
            weapons[number].SetActive(false);
            weaponCharacters[number].SetActive(false);
            Next.SetActive(false);
            Previous.SetActive(false);
            CanvasIsWork = false;
            shopRoot.SetActive(false);
        }
    }


    public void OpenShop()
    {
        InShop = true;
    }
    public void CloseShop()
    {
        InShop = false;
    }
    public void NextWeapon()
    {
        weapons[number].SetActive(false);
        weapons[number + 1].SetActive(true);
        weaponCharacters[number].SetActive(false);
        weaponCharacters[number + 1].SetActive(true);
        number = number + 1;
    }

    public void PreviousWeapon()
    {
        weapons[number].SetActive(false);
        weapons[number - 1].SetActive(true);
        weaponCharacters[number].SetActive(false);
        weaponCharacters[number - 1].SetActive(true);
        number = number - 1;
    }

}

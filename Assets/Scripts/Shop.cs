using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool InShop = false;
    public GameObject[] weapons;
    private int number = 0;
    private bool CanvasIsWork = false;

    [SerializeField]
    private ShopCanvas shopCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (InShop)
        {
            shopCanvas.Canvas.SetActive(true);
            weapons[number].SetActive(true);
            shopCanvas.weaponCharacters[number].SetActive(true);
            shopCanvas.Next.SetActive(true);
            shopCanvas.Previous.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CanvasIsWork = true;
           

        }

        if (number < 3 && CanvasIsWork)
        {
            shopCanvas.Next.SetActive(true);
        }
        else
        {
            shopCanvas.Next.SetActive(false);
        }


        if (number > 0 && CanvasIsWork)
        {
            shopCanvas.Previous.SetActive(true);
        }
        else
        {
            shopCanvas.Previous.SetActive(false);
        }
        
        if(!InShop)
        {
            
            weapons[number].SetActive(false);
            shopCanvas.weaponCharacters[number].SetActive(false);
            shopCanvas.Next.SetActive(false);
            shopCanvas.Previous.SetActive(false);
            CanvasIsWork = false;
            shopCanvas.Canvas.SetActive(false);
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
        shopCanvas.weaponCharacters[number].SetActive(false);
        shopCanvas.weaponCharacters[number + 1].SetActive(true);
        number = number + 1;
    }

    public void PreviousWeapon()
    {
        weapons[number].SetActive(false);
        weapons[number - 1].SetActive(true);
        shopCanvas.weaponCharacters[number].SetActive(false);
        shopCanvas.weaponCharacters[number - 1].SetActive(true);
        number = number - 1;
    }

}

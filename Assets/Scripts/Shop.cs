using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Camera PlayerCamera;
    public Camera ShopCamera;
    private bool InShop = false;
    public GameObject[] weapons;
    public GameObject player;
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
        if (Input.GetKeyDown(KeyCode.E) && InShop)
        {
            PlayerCamera.enabled = false;
            ShopCamera.enabled = true;
            weapons[number].SetActive(true);
            player.SetActive(false);
            shopCanvas.weaponCharacters[number].SetActive(true);
            shopCanvas.Next.SetActive(true);
            shopCanvas.Previous.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CanvasIsWork = true;
            shopCanvas.ShopLeaveTxt.SetActive(true);

        }

        if (CanvasIsWork)
        {
            shopCanvas.ShopEnterTxt.SetActive(false);
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
        
        if(!shopCanvas.ShopLeaveTxt.activeSelf)
        {
            PlayerCamera.enabled = true;
            ShopCamera.enabled = false;
            weapons[number].SetActive(false);
            player.SetActive(true);
            shopCanvas.weaponCharacters[number].SetActive(false);
            shopCanvas.Next.SetActive(false);
            shopCanvas.Previous.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CanvasIsWork = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            shopCanvas.ShopEnter();
            InShop = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            shopCanvas.ShopExit();
            InShop = false;

        }
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

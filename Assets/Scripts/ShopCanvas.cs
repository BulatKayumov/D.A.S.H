using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvas : MonoBehaviour
{

    public GameObject ShopEnterTxt;
    public GameObject Next;
    public GameObject Previous;
    public GameObject[] weaponCharacters;
    public GameObject Canvas;
    public GameObject ShopLeaveTxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShopEnter()
    {
        ShopEnterTxt.SetActive(true);
    }
    public void ShopExit()
    {
        ShopEnterTxt.SetActive(false);

    }
    public void ShopExitButton()
    {
        ShopLeaveTxt.SetActive(false);
    }    
}


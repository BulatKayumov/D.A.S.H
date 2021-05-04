using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public int MHP = 100;
    public int PlayerHP;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Damage")
            PlayerHP -= 25;
        if (collision.gameObject.tag == "+HP")
            PlayerHP = PlayerHP + 10;

    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = 100;
        print(PlayerHP);
    }

    // Update is called once per frame
    void Update()
    {
        print(PlayerHP);

    }
}

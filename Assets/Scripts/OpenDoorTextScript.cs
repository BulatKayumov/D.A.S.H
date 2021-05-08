using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTextScript : MonoBehaviour
{

    private Animator _animator;

    public GameObject OpenText = null;
    private bool NearDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenText.SetActive(true);
            NearDoor = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("open", false);
            OpenText.SetActive(false);
            NearDoor = false;
        }
    }

    private bool IsOpenTextActive
    {
        get
        {
            return OpenText.activeInHierarchy;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && NearDoor)
        {
            OpenText.SetActive(false);
            _animator.SetBool("open", true);
        }
    }
}
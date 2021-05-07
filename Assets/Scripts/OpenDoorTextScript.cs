using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTextScript : MonoBehaviour
{

    private Animator _animator;

    public GameObject OpenText = null;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();

       
        
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            OpenText.SetActive(true);

        }
    }

     void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("open", false);
            OpenText.SetActive(false);
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
        if(Input.GetKeyDown(KeyCode.E) && OpenText.activeSelf)
        {
            OpenText.SetActive(false);
            _animator.SetBool("open", true);
        }
    }
}

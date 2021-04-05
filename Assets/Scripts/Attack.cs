using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    
    
    
    string[] attacks = {"Attack1", "Attack2", "Attack3"}; 
    
    public void PlayRandomAttackAnimation()
    {
        animator.SetTrigger(attacks[UnityEngine.Random.Range(0, 3)]);
        
        
    }
    // Start is called before the first frame update
    void Start()
    
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        bool attackPressed = Input.GetMouseButtonDown(0);
        
    }
}

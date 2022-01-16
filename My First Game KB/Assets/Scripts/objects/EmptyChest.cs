using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyChest : Sign
{
    private bool oppened = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                contextOn.Raise();
            }
            else
            {
                if(!oppened)
                {
                    animator.SetBool("Oppened",true);
                    dialogBox.SetActive(true);
                    dialogText.text = dialog;
                    contextOff.Raise();
                    oppened = true;
                }
            }
        }
    }
}

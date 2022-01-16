using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Princess : Sign
{
    public GameObject Love;
    public GameObject ogrAlive;
    // Start is called before the first frame update
    void Start()
    {
        
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
                if (!ogrAlive)
                {
                    SceneManager.LoadScene("MainMenu");
                }
                
            }
            else
            {
                dialogText.text = "Oh mighty knight you need to beat ogr first";
                if(!ogrAlive)
                {
                    dialogText.text = dialog;
                    Love.SetActive(true);
                }
                dialogBox.SetActive(true);               
                contextOff.Raise();
            }
        }
    }
}

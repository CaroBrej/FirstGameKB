using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContexClue : MonoBehaviour
{
    public GameObject contexClue;

    public void Enable()
    {
        contexClue.SetActive(true);
    }

    public void Disable()
    {
        contexClue.SetActive(false);
    }
}

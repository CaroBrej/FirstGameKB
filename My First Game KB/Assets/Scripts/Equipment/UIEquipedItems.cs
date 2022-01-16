using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEquipedItems : MonoBehaviour
{
    public EquippedItems equippedItems;
    public EquippedItems baseEquippedItems;
    public GameObject InventoryBox;
    public GameObject ButtonsEIRD;

    public Text weponNameText;
    public Text headNameText;
    public Text bodyNameText;
    public Text armsNameText;
    public Text legsNameText;
    public Text bootsNameText;
    public Text neckNameText;
    public Text ringNameText;

    public GameObject weponObj;
    public GameObject headObj;
    public GameObject bodyObj;
    public GameObject armsObj;
    public GameObject legsObj;
    public GameObject bootsObj;
    public GameObject neckObj;
    public GameObject ringObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(InventoryBox.activeInHierarchy)
        {
            RefreshEquipped();
        }
    }

    public void RefreshEquipped()
    {
        weponNameText.text = equippedItems.items[0].EqName;
        weponObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[0],baseEquippedItems.items[0]); });
        headNameText.text = equippedItems.items[1].EqName;
        headObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[1], baseEquippedItems.items[1]); });
        bodyNameText.text = equippedItems.items[2].EqName;
        bodyObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[2], baseEquippedItems.items[2]); });
        armsNameText.text = equippedItems.items[3].EqName;
        armsObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[3], baseEquippedItems.items[3]); });
        legsNameText.text = equippedItems.items[4].EqName;
        legsObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[4], baseEquippedItems.items[4]); });
        bootsNameText.text = equippedItems.items[5].EqName;
        bootsObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[5], baseEquippedItems.items[5]); });
        neckNameText.text = equippedItems.items[6].EqName;
        neckObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[6], baseEquippedItems.items[6]); });
        ringNameText.text = equippedItems.items[7].EqName;
        ringObj.GetComponent<Button>().onClick.AddListener(delegate { ButtonsIR(equippedItems.items[7], baseEquippedItems.items[7]); });
    }

    
    public void ButtonsIR(EQstats itemInspect,EQstats itemRemove)
    {
        ButtonsEIRD.GetComponent<InventoryButtons>().itemToInspect = itemInspect;
        ButtonsEIRD.GetComponent<InventoryButtons>().itemToRemove = itemRemove;
    }
}

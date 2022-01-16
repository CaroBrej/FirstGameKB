using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{   
    public GameObject Player;

    public GameObject InventoryBox;
    public GameObject Table;   
    public GameObject ItemNamePrefab;
    public GameObject ButtonsEIRD;

    //public Text ItemNameText;

    public PLayerEq Items;
   
    private bool refreshed = false;
    private float TextPosition=25f;
    private List<GameObject> listOfItems=new List<GameObject>();
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(!InventoryBox.activeInHierarchy)
            {
                InventoryBox.SetActive(true);
                if(!refreshed)
                {
                    InventoryUpdate();
                    refreshed = true;
                }
            }else
            {
                InventoryClear();
                InventoryBox.SetActive(false);
                refreshed = false;
            }
        }
    }
   

    public void InventoryUpdate()
    {
        float i = 0f;
        
        foreach (EQstats item in Items.Items)
        {
            Vector3 position = new Vector3(Table.transform.position.x+40f, Table.transform.position.y+120f - TextPosition * i, Table.transform.position.z);
            GameObject clone=Instantiate(ItemNamePrefab,position, ItemNamePrefab.transform.rotation, Table.transform);
            clone.GetComponent<Text>().text = item.EqName;
            clone.GetComponent<ItemStats>().stats = item;
            clone.GetComponent<Button>().onClick.AddListener(delegate { ButtonsEID(item); });
            listOfItems.Add(clone);
            i++;
            
        }
    }
    public void InventoryClear()
    {
        foreach (var item in listOfItems)
        {
            Destroy(item);
        }
        listOfItems.Clear();
    }

    public void ButtonsEID(EQstats item)
    {
        ButtonsEIRD.GetComponent<InventoryButtons>().itemToEquip = item;
        ButtonsEIRD.GetComponent<InventoryButtons>().itemToInspect = item;
        ButtonsEIRD.GetComponent<InventoryButtons>().itemToDestroy = item;
    }
}

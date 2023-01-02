using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;


public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;
    public TextMeshProUGUI t1;
    public TextMeshProUGUI t2;
    public TextMeshProUGUI t3;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;

    public Transform loc1;
    public Transform loc2;
    public Transform loc3;

    public Transform currentloc;


    [System.Serializable]
    public class Product
    {
        public string name;
        public string type;
        public int price;
        public string info;
    }

    [System.Serializable]
    public class ProductList
    {
        public Product[] product;
    }
    public ProductList myProductList = new ProductList();


    // Start is called before the first frame update
    void Start()
    {
        myProductList= JsonUtility.FromJson<ProductList>(textJSON.text);

        int count_of_instantiated = 0;
        currentloc = loc1;
        for (int i=0;i<3;i++)
        {
            if (myProductList.product[i].type == "phone")
            {
                Instantiate(prefab2, currentloc);
                count_of_instantiated++;
            }
            else if (myProductList.product[i].type == "tab")
            {
                PhotonNetwork.InstantiateRoomObject("Tablet_Purple", currentloc.position, Quaternion.identity, 0);
                
                count_of_instantiated++;
            }
            else
            {
                Instantiate(prefab3, currentloc);
                count_of_instantiated++;
            }
                
            if (count_of_instantiated == 1)
            {
                currentloc = loc2;
                t1.text = myProductList.product[i].name;
                t1.text += "\n\n" + myProductList.product[i].price + " pkr";
                t1.text += "\n\n" + "Info: " + myProductList.product[i].info;
            }
                
            else if (count_of_instantiated == 2)
            {
                currentloc = loc3;
                t2.text = myProductList.product[i].name;
                t2.text += "\n\n" + myProductList.product[i].price + " pkr";
                t2.text += "\n\n" + "Info: " + myProductList.product[i].info;
            }
            else
            {
                t3.text = myProductList.product[i].name;
                t3.text += "\n\n" + myProductList.product[i].price + " pkr";
                t3.text += "\n\n" + "Info: " + myProductList.product[i].info;

            }
                
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

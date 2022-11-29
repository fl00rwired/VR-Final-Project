using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace products
{
    [AddComponentMenu("Products/Base Product Manager")]
    public class BaseProductManager : MonoBehaviour
    {
        [Header("JSON to Read from")]
        public TextAsset textJSON;

        [Header("3D Objects to display")]
        public GameObject prefab1;
        public GameObject prefab2;
        public GameObject prefab3;

        [Header("Spawn Locations")]
        public Transform loc1;
        public Transform loc2;
        public Transform loc3;

        [Header("UI Display Text")]
        public TextMeshProUGUI t1;
        public TextMeshProUGUI t2;
        public TextMeshProUGUI t3;

        private Transform currentloc;
        private int count_of_instantiated;

        [System.Serializable]
        public class Product
        {
            public string pname;
            public string type;
            public int price;
            public string info;
        }

        [System.Serializable]
        public class ProductList
        {
            public Product[] product;
        }

        public static ProductList global_productData;
      
        public bool didInit;

       

        public void Init()
        {
            global_productData = new ProductList();
            count_of_instantiated = 0;
            if (global_productData == null)
                global_productData = new ProductList();
            didInit = true;
        }

        public void ResetUsers()
        {
            if (!didInit)
            Init();
            global_productData = new ProductList();
        }


        public ProductList GetProductList()
        {
            if (global_productData == null)
                Init();
            return global_productData;
        }


        public void Store_to_UI()
        {
            currentloc = loc1;
            for (int i = 0; i < 3; i++)
            {
                if (global_productData.product[i].type == "phone")
                {
                    Instantiate(prefab1, currentloc);
                    count_of_instantiated++;
                }
                else if (global_productData.product[i].type == "tab")
                {
                    Instantiate(prefab2, currentloc);
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
                    t1.text = global_productData.product[i].pname;
                    t1.text += "\n\n" + global_productData.product[i].price + " pkr";
                    t1.text += "\n\n" + "Info: " + global_productData.product[i].info;
                }

                else if (count_of_instantiated == 2)
                {
                    currentloc = loc3;
                    t2.text = global_productData.product[i].pname;
                    t2.text += "\n\n" + global_productData.product[i].price + " pkr";
                    t2.text += "\n\n" + "Info: " + global_productData.product[i].info;
                }
                else
                {
                    t3.text = global_productData.product[i].pname;
                    t3.text += "\n\n" + global_productData.product[i].price + " pkr";
                    t3.text += "\n\n" + "Info: " + global_productData.product[i].info;

                }

            }
        }

        

        public void read_json()
        {
            global_productData = JsonUtility.FromJson<ProductList>(textJSON.text);
        }

        // Start is called before the first frame update
        void Start()
        {
            Init();
            read_json();
            Store_to_UI();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}



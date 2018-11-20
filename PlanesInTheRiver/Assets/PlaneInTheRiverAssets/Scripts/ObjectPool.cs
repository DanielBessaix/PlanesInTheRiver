using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZenvaVR
{
    public class ObjectPool : MonoBehaviour {
        
        public GameObject poolPrefab;
        public GameObject ennemi2;
        
        public int initialNum = 10;
        
        List<GameObject> pooledObjects;
        
        void Awake()
        {
            if(pooledObjects == null)
            {
                InitPool();
            }
        }
        
        public void InitPool()
        {
            pooledObjects = new List<GameObject>();
            
            for (int i = 0; i < initialNum; i++)
            {
                CreateRandomEnnemi();
            }
        }
        
        GameObject CreateObj()
        {
            GameObject newObj = Instantiate(poolPrefab);
            
            newObj.SetActive(false);
            
            pooledObjects.Add(newObj);

            return newObj;
        }

        GameObject CreateObj2()
        {
            GameObject newObj = Instantiate(ennemi2);

            newObj.SetActive(false);

            pooledObjects.Add(newObj);

            return newObj;
        }

        GameObject CreateRandomEnnemi()
        {
            int i = Random.Range(0, 10);
            if (i < 8)
            {
                return CreateObj();
            }
            else
            {
                return CreateObj2();
            }
        }

        public GameObject GetObj()
        {
            for(int i = 0; i < pooledObjects.Count; i++) {
                
                if(!pooledObjects[i].activeInHierarchy)
                {
                    pooledObjects[i].SetActive(true);
                    
                    return pooledObjects[i];
                }
            }
            
            GameObject newObj = CreateRandomEnnemi();
            
            newObj.SetActive(true);
            
            return newObj;
        }
        
        public List<GameObject> GetAllActive()
        {
            List<GameObject> activeObjs;
            activeObjs = new List<GameObject>();
            
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (pooledObjects[i].activeInHierarchy)
                {
                    activeObjs.Add(pooledObjects[i]);
                }
            }

            return activeObjs;
        }
    }
}
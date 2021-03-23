using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PoolManager _poolmanager;
    private List<IUpdater> _listTest = new List<IUpdater>();
    public Vector3 position;

    private void Start()
    {
        _poolmanager = gameObject.GetComponent<PoolManager>();
        _poolmanager.Initialize();
        
        _listTest.Add(new SystemUpdateMoveLinearComponent());
       
        
        Entity entity = _poolmanager.GetPooledObject(ObjectType.Ennemy);
        entity.Init();
        Entity entityp = _poolmanager.GetPooledObject(ObjectType.Player);
        Debug.Log(entityp);
        entityp.Init();
    }
    
      IEnumerator ExampleCoroutine()
     { 
         yield return new WaitForSeconds(UnityEngine.Random.Range(20f,40f));
     }

    
    private void Update()
    {
        foreach (var system in _listTest)
        {
            system.SystemUpdate();
        }

        ExampleCoroutine();

            Entity entity = _poolmanager.GetPooledObject(ObjectType.Ennemy);
            if (entity)
            {
                entity.Init();
            }
 
            position = new Vector3(UnityEngine.Random.Range(-80.0F, 80.0F), 0, UnityEngine.Random.Range(40.0F, 80.0F));
            entity.gameObject.transform.position = position;
        
    }
}

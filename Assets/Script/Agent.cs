using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Agent : MonoBehaviour
{
[SerializeField] Transform  _destination;
NavMeshAgent _navMeshAgent;
public Camera cam;

    // Start is called before the first frame update
    void Start()  
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent ==null)
        {
            Debug.LogError("Nav Mesh Agent is not moving to " + gameObject.name);
        }
        else
        {
            SetDestination(); 
        } 
    }
   private void Update() {
       if(Input.GetMouseButtonDown(0)){
           Ray ray = cam.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;

           if(Physics.Raycast(ray, out hit)){
               _navMeshAgent.SetDestination(hit.point);
           }
       }
       
   }

    public void SetDestination()
    {
        if(_destination != null)
        {

            Vector3 targetVector = _destination.transform.position;

            _navMeshAgent.SetDestination(targetVector);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform rotationPoint; //rotation point 
    [SerializeField] private LayerMask enemyMask; //enemy layer
    [SerializeField] private GameObject bulletPrefab; //ref to bullets
    [SerializeField] private Transform firingPoint; //ref to barrel

    [Header("Attribute")]
    [SerializeField] private float turretRange = 2.5f; // range of turret
    [SerializeField] private float rotateSpeed = 100f; //rotation speed of turret
    [SerializeField] private float bps = 1f; //bullets per second 

    //transform variable to hold current target;
    private Transform target;
     private float timeUntilFire;

    //method to find a target
    private void FindTarget(){
        //detecting all enemy objects in the range
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, turretRange, (Vector2)transform.position, 0f, enemyMask);

        //if an enemy exists, target is set to first detected
        if(hits.Length > 0){
            target = hits[0].transform;
        }
    }

    //method to rotate the turret
    private void RotateToTarget(){
        //calculating turning angle by using arc-tan
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        //setting target rotation to calculated angle in Z axis.
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        //change rotation of the rotPoint by calculated targetRotation, in rotateSpeed time.
        rotationPoint.rotation = Quaternion.RotateTowards(rotationPoint.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    //checks if target is in range
    private bool CheckTargetInRange(){
        return Vector2.Distance(target.position, transform.position) <= turretRange;
    }

    //draws a range disc around turret
    private void OnDrawGizmosSelected(){
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, turretRange);
    }

    private void Fire(){
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (target == null){
            FindTarget();
            return;
        }

        RotateToTarget();

        if(!CheckTargetInRange()){
            target = null;
        }else{
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bps){
                Fire();
                timeUntilFire = 0f;
            }
        }
    }
}

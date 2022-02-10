//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class TestTrigger : MonoBehaviour
//{
//    public PhysicalSkill physicalSkill;

//    protected GameObject target;
//    public string targetTag;
//    protected bool targetInRange;

//    private void OnTriggerEnter(Collider other) {
//        if (other.gameObject.tag == targetTag)
//        {
//            Debug.Log("enemy in range");
//            //targetInRange = true;
//            target = other.gameObject;

//            physicalSkill.isTarget = true;

//            physicalSkill.HitTarget(other);

//            //apply damage
//            target.GetComponent<Health>().health -= physicalSkill.damage/*get damage from skill in use???*/;

//        }
//    }
//    private void OnTriggerExit(Collider other){
//        if (other.gameObject.tag == targetTag)
//        {
//            Debug.Log("enemy out of range");
//            targetInRange = false;
//            target = null;

//            physicalSkill.isTarget = false;
//        }
//    }
//}

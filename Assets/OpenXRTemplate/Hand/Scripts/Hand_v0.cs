//using System;
//using UnityEngine;

//[RequireComponent(typeof(Animator))]
//public class Hand : MonoBehaviour
//{
//    //Animation
//    private Animator _animator;
//    private float _gripTarget;
//    private float _triggerTarget;
//    private float _gripCurrent;
//    private float _triggerCurrent;
//    [SerializeField]private float animationSpeed=10f;

//    // Physics Movement
//    [SerializeField] private GameObject followobject; 
//    [SerializeField] private float followSpeed = 30f; 
//    [SerializeField] private float rotateSpeed = 100f; 
//    [SerializeField] private Vector3 positionOffset; 
//    [SerializeField] private Vector3 rotationOffset; 
//       private Transform _followTarget;
//       private Rigidbody _body;

//    void Start()
//    {
//        _animator = GetComponent<Animator>();

//        // Physics Movement
//        _followTarget = followobject.transform;
//        _body = GetComponent<Rigidbody>();
//        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
//        _body.interpolation = RigidbodyInterpolation.Interpolate;
//        _body.mass = 20f;
//        // Teleport hands
//        _body.position = _followTarget.position;
//        _body.rotation = _followTarget.rotation;
//    }
//    void Update()
//    {
//        AnimateHand();
//        PhysicsMove();
//    }

//    private void PhysicsMove()
//    {
//        // Position
//        var positionWithOffset = _followTarget.position + positionOffset;
//        var distance = Vector3.Distance(positionWithOffset, transform.position);
//        _body.velocity= (_followTarget.position - transform.position).normalized * (followSpeed * distance);

//        //Rotation
//        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
//        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
//        q.ToAngleAxis(out float angle, out Vector3 axis);
//        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
//    }

//    internal void SetGrip(float v)
//    {
//        _gripTarget = v;
//    }
//    internal void SetTrigger(float v)
//    {
//        _triggerTarget = v;
//    }

//    void AnimateHand()
//    {

//        if (_gripCurrent != _gripTarget)
//        {
//            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * animationSpeed);
//            _animator.SetFloat("Grip", _gripCurrent);
//        }

//        if (_triggerCurrent != _triggerTarget)
//        {
//            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * animationSpeed);
//            _animator.SetFloat("Grip", _triggerCurrent);
//        }
//    }
//}
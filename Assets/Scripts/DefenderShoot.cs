using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderShoot : MonoBehaviour
{

    [SerializeField] private GameObject _zucchiniGameObject;
    [SerializeField] private GameObject _gunGameObject;
    
    public void Fire()
    {
        Instantiate(_zucchiniGameObject, _gunGameObject.transform.position, transform.rotation);
    }
}

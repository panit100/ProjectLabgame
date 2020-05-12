using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLine : MonoBehaviour
{
    Ray shootRay;
    LineRenderer gunLine;
    public PlayerShooting playerShooting;

    void Awake()
    {
        gunLine = GetComponent<LineRenderer>();        
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        GuideLinePerk();
    }

    void GuideLinePerk(){
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;
        
        gunLine.SetPosition(0,transform.position);
        
        gunLine.SetPosition(1,shootRay.origin+shootRay.direction * playerShooting.weapons[playerShooting.currentWeapon].range);

    }
}

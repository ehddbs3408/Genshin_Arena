using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable 
{
    int Health { get; set; }
    void OnGethit(int damaged,GameObject dealer);
    void OnDead();
}

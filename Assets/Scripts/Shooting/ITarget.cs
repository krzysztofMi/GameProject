using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITarget{
    void TakeDamage(float takenDmg);
    float getHealth();
    void setHealth(float health);
}

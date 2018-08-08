using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP2 : MonoBehaviour {
    
    float maxHP = 1f;
    public float currentHP;

    public float normalizeHP { get { return currentHP / maxHP; } }

    public void ModifyHP(float addValue){
        currentHP += addValue;
    }
}

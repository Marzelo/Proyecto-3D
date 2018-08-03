using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour {

    float maxHP = 1f;
    public float currentHP;

    public float normalizeHP { get { return currentHP / maxHP; } }

    public void ModifyHP(float addValue){
        currentHP = Mathf.Clamp(currentHP + addValue, 0, maxHP);
    }

}

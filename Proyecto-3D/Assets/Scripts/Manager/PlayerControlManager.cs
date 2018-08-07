using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour {

    static public PlayerControlManager instance;
    public Player player;
    public Caminante caminante;
    public Barco2 barco2;

	void Awake(){
        if ( instance == null){
            instance = this;
        }
	}

    public void ControlBarco () {
        bool enabled = player.enabled;
        player.enabled = caminante.enabled;
        caminante.enabled = enabled;
    }

    public void ControlBarco2(){
        bool enabled = player.enabled;
        player.enabled = barco2.enabled;
        barco2.enabled = enabled;
    }

    public void ControlCanon(Canon canon){
        bool enabled = player.enabled;
        player.enabled = canon.enabled;
        canon.enabled = enabled;
    }
}

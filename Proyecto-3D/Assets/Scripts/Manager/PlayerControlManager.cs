using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour {

    static public PlayerControlManager instance;
    public Player player;
    public Caminante caminante;

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

    public void ControlBarco2(Barco2 barco2){
        bool enabled = player.enabled;
        player.enabled = caminante.enabled;
        caminante.enabled = enabled;
    }

    public void ControlCanon(Canon canon){
        bool enabled = player.enabled;
        player.enabled = canon.enabled;
        canon.enabled = enabled;
    }
}

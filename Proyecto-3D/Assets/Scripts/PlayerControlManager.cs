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

    public void SwapControl () {
        bool enabled = player.enabled;
        player.enabled = caminante.enabled;
        caminante.enabled = enabled;
    }
}

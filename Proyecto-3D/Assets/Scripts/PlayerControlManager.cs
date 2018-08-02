using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour {

    static public PlayerControlManager instance;
    public Player player;
    public Caminante caminante;
    public Cañon canon;

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

    public void SwapControl2()
    {
        bool enabled = player.enabled;
        player.enabled = canon.enabled;
        canon.enabled = enabled;
    }

}

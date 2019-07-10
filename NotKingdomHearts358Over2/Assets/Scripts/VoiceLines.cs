using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class VoiceLines : NetworkBehaviour
{

    private SFXManager SFXM;

    public SFXGroup AttackLines;
    public SFXGroup AttackFinishLines;
    public SFXGroup AttackQuotes;
    public SFXGroup DamageLines;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Server]
    public void Attack()
    {
        SFXManager.Main.Play(AttackLines);
    }

    [Server]
    public void Finisher()
    {

        int rand = Random.RandomRange(0, 1);
        if(rand == 0){
            SFXManager.Main.Play(AttackFinishLines);

        }
        else
        {
            Quote();
        }

    }

    [Server]
    public void Quote()
    {
    }


}

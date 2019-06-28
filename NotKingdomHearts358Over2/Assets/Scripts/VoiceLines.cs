using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceLines : MonoBehaviour
{

    private SFXManager SFXM;

    public SFXGroup AttackLines;
    public SFXGroup AttackFinishLines;
    public SFXGroup AttackQuotes;
    public List<SFXObject> DamageLines;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        SFXManager.Main.Play(AttackLines);
    }
    public void Finisher()
    {
        SFXManager.Main.Play(AttackFinishLines);
    }
    public void Quote()
    {
        SFXManager.Main.Play(AttackQuotes);
    }

}

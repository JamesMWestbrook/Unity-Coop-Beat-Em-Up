// GENERATED AUTOMATICALLY FROM 'Assets/Input/UnityTutorial.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class UnityTutorial : InputActionAssetReference
{
    public UnityTutorial()
    {
    }
    public UnityTutorial(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Ship
        m_Ship = asset.GetActionMap("Ship");
        m_Ship_fire = m_Ship.GetAction("fire");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Ship = null;
        m_Ship_fire = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Ship
    private InputActionMap m_Ship;
    private InputAction m_Ship_fire;
    public struct ShipActions
    {
        private UnityTutorial m_Wrapper;
        public ShipActions(UnityTutorial wrapper) { m_Wrapper = wrapper; }
        public InputAction @fire { get { return m_Wrapper.m_Ship_fire; } }
        public InputActionMap Get() { return m_Wrapper.m_Ship; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(ShipActions set) { return set.Get(); }
    }
    public ShipActions @Ship
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new ShipActions(this);
        }
    }
}

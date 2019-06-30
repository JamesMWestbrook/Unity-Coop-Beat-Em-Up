// GENERATED AUTOMATICALLY FROM 'Assets/Input/New Controls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class NewControls : InputActionAssetReference
{
    public NewControls()
    {
    }
    public NewControls(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_MoveCamera = m_Player.GetAction("Move Camera");
        m_Player_shoot = m_Player.GetAction("shoot");
        m_Player_Newaction = m_Player.GetAction("New action");
        // New action map1
        m_Newactionmap1 = asset.GetActionMap("New action map1");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player = null;
        m_Player_MoveCamera = null;
        m_Player_shoot = null;
        m_Player_Newaction = null;
        m_Newactionmap1 = null;
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
    // Player
    private InputActionMap m_Player;
    private InputAction m_Player_MoveCamera;
    private InputAction m_Player_shoot;
    private InputAction m_Player_Newaction;
    public struct PlayerActions
    {
        private NewControls m_Wrapper;
        public PlayerActions(NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveCamera { get { return m_Wrapper.m_Player_MoveCamera; } }
        public InputAction @shoot { get { return m_Wrapper.m_Player_shoot; } }
        public InputAction @Newaction { get { return m_Wrapper.m_Player_Newaction; } }
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
    }
    public PlayerActions @Player
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new PlayerActions(this);
        }
    }
    // New action map1
    private InputActionMap m_Newactionmap1;
    public struct Newactionmap1Actions
    {
        private NewControls m_Wrapper;
        public Newactionmap1Actions(NewControls wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Newactionmap1Actions set) { return set.Get(); }
    }
    public Newactionmap1Actions @Newactionmap1
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new Newactionmap1Actions(this);
        }
    }
    private int m_KeyboardandmouseSchemeIndex = -1;
    public InputControlScheme KeyboardandmouseScheme
    {
        get

        {
            if (m_KeyboardandmouseSchemeIndex == -1) m_KeyboardandmouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard and mouse");
            return asset.controlSchemes[m_KeyboardandmouseSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get

        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.GetControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
}

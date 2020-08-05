// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""b0c599c4-42bf-4d12-a03d-f7eb337567e1"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""9f03a607-32c5-411e-86bd-21a5d8224b6b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AttackLeft"",
                    ""type"": ""Button"",
                    ""id"": ""f36176d4-3b04-4d7f-abaa-8340645e680e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""AttackRight"",
                    ""type"": ""Button"",
                    ""id"": ""7b9b198a-6aee-4f20-b94d-51ede15ab0b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""04f6f29d-ecfb-4c50-8974-4c865627e1b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""419b028c-4bde-4add-9ee1-1e6523350eed"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""fc2a802e-4fe5-4002-9973-352d8c9b8108"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CameraLeft"",
                    ""type"": ""Button"",
                    ""id"": ""759263bf-bea6-4e10-a2e9-3ee3b4762318"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""CameraRight"",
                    ""type"": ""Button"",
                    ""id"": ""92c5fea7-032e-4efc-8c8a-606af485f262"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""3e577d25-1e4a-434d-9f3c-df2274619ea2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Shove"",
                    ""type"": ""Button"",
                    ""id"": ""869b0a0d-85b7-4621-9150-b3984bba35c8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""21bc6329-474d-4dcb-a0c7-31f73234e1c1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""AttackLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b9f834b-40c3-4002-a88c-de674d47c2da"",
                    ""path"": ""<Keyboard>/leftAlt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""52e48c69-4b99-4a75-bba4-80969caa05e2"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AttackRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6860aa7-555b-4c6f-928d-6b4e539a32d2"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3799a152-27df-4c19-8fb6-07644f502895"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""684fd27d-061e-4ac5-b0c1-a075c7d51fb6"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""CameraLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e00f9eeb-a593-42aa-b87f-c039ec297caf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""CameraRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8b4d549-1bd6-4b56-9e56-7bf8fb09865a"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f4dd2b82-8715-457a-a58f-b456c78bd8ed"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Shove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""wsad"",
                    ""id"": ""8e154d91-cebe-41c8-a39c-cdd1cfd94e61"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bbb6c0be-a55f-45ff-a3e7-dfce4804cb70"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""68d2842a-4cfb-4125-8768-d7586e8a5edd"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7b2cda97-450b-4298-81be-403179c56d9b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a812e7a3-7cc6-45dd-9cd2-0b5938713709"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keybord and mouse"",
            ""bindingGroup"": ""Keybord and mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_AttackLeft = m_Player.FindAction("AttackLeft", throwIfNotFound: true);
        m_Player_AttackRight = m_Player.FindAction("AttackRight", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_Drop = m_Player.FindAction("Drop", throwIfNotFound: true);
        m_Player_CameraLeft = m_Player.FindAction("CameraLeft", throwIfNotFound: true);
        m_Player_CameraRight = m_Player.FindAction("CameraRight", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_Shove = m_Player.FindAction("Shove", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_AttackLeft;
    private readonly InputAction m_Player_AttackRight;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_Drop;
    private readonly InputAction m_Player_CameraLeft;
    private readonly InputAction m_Player_CameraRight;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_Shove;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @AttackLeft => m_Wrapper.m_Player_AttackLeft;
        public InputAction @AttackRight => m_Wrapper.m_Player_AttackRight;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @Drop => m_Wrapper.m_Player_Drop;
        public InputAction @CameraLeft => m_Wrapper.m_Player_CameraLeft;
        public InputAction @CameraRight => m_Wrapper.m_Player_CameraRight;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @Shove => m_Wrapper.m_Player_Shove;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @AttackLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLeft;
                @AttackLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLeft;
                @AttackLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackLeft;
                @AttackRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRight;
                @AttackRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRight;
                @AttackRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttackRight;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Drop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @CameraLeft.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLeft;
                @CameraLeft.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLeft;
                @CameraLeft.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraLeft;
                @CameraRight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraRight;
                @CameraRight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraRight;
                @CameraRight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCameraRight;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Shove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShove;
                @Shove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShove;
                @Shove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShove;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @AttackLeft.started += instance.OnAttackLeft;
                @AttackLeft.performed += instance.OnAttackLeft;
                @AttackLeft.canceled += instance.OnAttackLeft;
                @AttackRight.started += instance.OnAttackRight;
                @AttackRight.performed += instance.OnAttackRight;
                @AttackRight.canceled += instance.OnAttackRight;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @CameraLeft.started += instance.OnCameraLeft;
                @CameraLeft.performed += instance.OnCameraLeft;
                @CameraLeft.canceled += instance.OnCameraLeft;
                @CameraRight.started += instance.OnCameraRight;
                @CameraRight.performed += instance.OnCameraRight;
                @CameraRight.canceled += instance.OnCameraRight;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Shove.started += instance.OnShove;
                @Shove.performed += instance.OnShove;
                @Shove.canceled += instance.OnShove;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeybordandmouseSchemeIndex = -1;
    public InputControlScheme KeybordandmouseScheme
    {
        get
        {
            if (m_KeybordandmouseSchemeIndex == -1) m_KeybordandmouseSchemeIndex = asset.FindControlSchemeIndex("Keybord and mouse");
            return asset.controlSchemes[m_KeybordandmouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttackLeft(InputAction.CallbackContext context);
        void OnAttackRight(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnCameraLeft(InputAction.CallbackContext context);
        void OnCameraRight(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnShove(InputAction.CallbackContext context);
    }
}

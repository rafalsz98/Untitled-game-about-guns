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
                },
                {
                    ""name"": ""Equipment"",
                    ""type"": ""Button"",
                    ""id"": ""e5b7e2fc-07a9-4b97-a714-6a8c85f97acd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""DEBUG"",
                    ""type"": ""Button"",
                    ""id"": ""05483c74-58cf-4f09-8e6a-76be1e5260e5"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""1659ec6d-8b56-406b-a211-652440f560bc"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Equipment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e223d075-7370-4e4e-8081-75e46a939183"",
                    ""path"": ""<Keyboard>/slash"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""DEBUG"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""EquipmentGUI"",
            ""id"": ""6799414f-1ec8-432c-a290-b231d7570d0c"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""7f82bcb9-bd0c-44d8-9073-cab6bcaf52e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""261c53fe-4485-43f3-b2f4-98b7dff7319d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""e30cefcb-2565-4fac-855a-1754d0ac60a0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""ae717fee-a0ce-423a-bb57-3e12e0529998"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ed756b9c-9838-4620-9637-3114111950fa"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8932af6-5768-4628-bb6f-173865c89a01"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ddac3ab1-ead0-4afb-9a3a-72c8ba91a69c"",
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
                    ""id"": ""306dbd22-d3e6-4a55-8c85-aaf0851e10ca"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ws"",
                    ""id"": ""dd0eda42-b2a4-4fd9-99b5-3f29c510eaeb"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""57b902f3-818a-4b27-be26-4ae4b8d044de"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b00d63e7-3146-46ed-a5bb-8a062c4a85fe"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""05eb7ce4-f34c-4e4e-bd25-0cf9763249ee"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e42022ce-e776-46a6-8665-d74c12bd8808"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4752ab0d-b6f2-4b2d-b71a-50b6b97c8afa"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PickupGUI"",
            ""id"": ""08dd1f33-9601-4668-8e6f-87ffdc2af930"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""9f1e8eaf-45fa-4a35-813d-b31ab3165988"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""TakeAll"",
                    ""type"": ""Button"",
                    ""id"": ""fdc04229-8061-48ea-8d44-8c104604ccca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Take"",
                    ""type"": ""Button"",
                    ""id"": ""3ac5f2eb-243c-4554-bde7-945657a37276"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Navigate"",
                    ""type"": ""Value"",
                    ""id"": ""06213135-c888-440b-90aa-b0e3be667ac9"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ebc55513-4a8b-433b-b6c7-68205a364c2f"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""TakeAll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00dbdcde-3a00-407d-9311-ed148358fc88"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""589b415d-c3a6-453f-bb56-97b649720aa0"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a34a0e4-ce0f-4584-af09-da8d8cbeaae9"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Take"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57915e9f-f325-4206-b3e5-84393b6e113e"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Take"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""ws"",
                    ""id"": ""889a0dfc-db6e-40b3-bab4-b083294783b4"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6d153a3f-f364-4857-8177-8fcbb1c4a368"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""93070262-e898-486b-a764-d359544e3351"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""arrows"",
                    ""id"": ""70a71be7-41cc-445c-aedd-ebb6c11792f8"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""107d322c-29f7-4ffe-bb4e-e44d61826ffd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""aff52220-c854-4556-8569-48628afb2a4c"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keybord and mouse"",
                    ""action"": ""Navigate"",
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
        m_Player_Equipment = m_Player.FindAction("Equipment", throwIfNotFound: true);
        m_Player_DEBUG = m_Player.FindAction("DEBUG", throwIfNotFound: true);
        // EquipmentGUI
        m_EquipmentGUI = asset.FindActionMap("EquipmentGUI", throwIfNotFound: true);
        m_EquipmentGUI_Exit = m_EquipmentGUI.FindAction("Exit", throwIfNotFound: true);
        m_EquipmentGUI_Use = m_EquipmentGUI.FindAction("Use", throwIfNotFound: true);
        m_EquipmentGUI_Drop = m_EquipmentGUI.FindAction("Drop", throwIfNotFound: true);
        m_EquipmentGUI_Navigate = m_EquipmentGUI.FindAction("Navigate", throwIfNotFound: true);
        // PickupGUI
        m_PickupGUI = asset.FindActionMap("PickupGUI", throwIfNotFound: true);
        m_PickupGUI_Exit = m_PickupGUI.FindAction("Exit", throwIfNotFound: true);
        m_PickupGUI_TakeAll = m_PickupGUI.FindAction("TakeAll", throwIfNotFound: true);
        m_PickupGUI_Take = m_PickupGUI.FindAction("Take", throwIfNotFound: true);
        m_PickupGUI_Navigate = m_PickupGUI.FindAction("Navigate", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Equipment;
    private readonly InputAction m_Player_DEBUG;
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
        public InputAction @Equipment => m_Wrapper.m_Player_Equipment;
        public InputAction @DEBUG => m_Wrapper.m_Player_DEBUG;
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
                @Equipment.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEquipment;
                @Equipment.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEquipment;
                @Equipment.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEquipment;
                @DEBUG.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDEBUG;
                @DEBUG.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDEBUG;
                @DEBUG.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDEBUG;
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
                @Equipment.started += instance.OnEquipment;
                @Equipment.performed += instance.OnEquipment;
                @Equipment.canceled += instance.OnEquipment;
                @DEBUG.started += instance.OnDEBUG;
                @DEBUG.performed += instance.OnDEBUG;
                @DEBUG.canceled += instance.OnDEBUG;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // EquipmentGUI
    private readonly InputActionMap m_EquipmentGUI;
    private IEquipmentGUIActions m_EquipmentGUIActionsCallbackInterface;
    private readonly InputAction m_EquipmentGUI_Exit;
    private readonly InputAction m_EquipmentGUI_Use;
    private readonly InputAction m_EquipmentGUI_Drop;
    private readonly InputAction m_EquipmentGUI_Navigate;
    public struct EquipmentGUIActions
    {
        private @InputMaster m_Wrapper;
        public EquipmentGUIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Exit => m_Wrapper.m_EquipmentGUI_Exit;
        public InputAction @Use => m_Wrapper.m_EquipmentGUI_Use;
        public InputAction @Drop => m_Wrapper.m_EquipmentGUI_Drop;
        public InputAction @Navigate => m_Wrapper.m_EquipmentGUI_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_EquipmentGUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EquipmentGUIActions set) { return set.Get(); }
        public void SetCallbacks(IEquipmentGUIActions instance)
        {
            if (m_Wrapper.m_EquipmentGUIActionsCallbackInterface != null)
            {
                @Exit.started -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnExit;
                @Use.started -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnUse;
                @Drop.started -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnDrop;
                @Navigate.started -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_EquipmentGUIActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_EquipmentGUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public EquipmentGUIActions @EquipmentGUI => new EquipmentGUIActions(this);

    // PickupGUI
    private readonly InputActionMap m_PickupGUI;
    private IPickupGUIActions m_PickupGUIActionsCallbackInterface;
    private readonly InputAction m_PickupGUI_Exit;
    private readonly InputAction m_PickupGUI_TakeAll;
    private readonly InputAction m_PickupGUI_Take;
    private readonly InputAction m_PickupGUI_Navigate;
    public struct PickupGUIActions
    {
        private @InputMaster m_Wrapper;
        public PickupGUIActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Exit => m_Wrapper.m_PickupGUI_Exit;
        public InputAction @TakeAll => m_Wrapper.m_PickupGUI_TakeAll;
        public InputAction @Take => m_Wrapper.m_PickupGUI_Take;
        public InputAction @Navigate => m_Wrapper.m_PickupGUI_Navigate;
        public InputActionMap Get() { return m_Wrapper.m_PickupGUI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PickupGUIActions set) { return set.Get(); }
        public void SetCallbacks(IPickupGUIActions instance)
        {
            if (m_Wrapper.m_PickupGUIActionsCallbackInterface != null)
            {
                @Exit.started -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnExit;
                @TakeAll.started -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnTakeAll;
                @TakeAll.performed -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnTakeAll;
                @TakeAll.canceled -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnTakeAll;
                @Take.started -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnTake;
                @Take.performed -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnTake;
                @Take.canceled -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnTake;
                @Navigate.started -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnNavigate;
                @Navigate.performed -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnNavigate;
                @Navigate.canceled -= m_Wrapper.m_PickupGUIActionsCallbackInterface.OnNavigate;
            }
            m_Wrapper.m_PickupGUIActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @TakeAll.started += instance.OnTakeAll;
                @TakeAll.performed += instance.OnTakeAll;
                @TakeAll.canceled += instance.OnTakeAll;
                @Take.started += instance.OnTake;
                @Take.performed += instance.OnTake;
                @Take.canceled += instance.OnTake;
                @Navigate.started += instance.OnNavigate;
                @Navigate.performed += instance.OnNavigate;
                @Navigate.canceled += instance.OnNavigate;
            }
        }
    }
    public PickupGUIActions @PickupGUI => new PickupGUIActions(this);
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
        void OnEquipment(InputAction.CallbackContext context);
        void OnDEBUG(InputAction.CallbackContext context);
    }
    public interface IEquipmentGUIActions
    {
        void OnExit(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
    public interface IPickupGUIActions
    {
        void OnExit(InputAction.CallbackContext context);
        void OnTakeAll(InputAction.CallbackContext context);
        void OnTake(InputAction.CallbackContext context);
        void OnNavigate(InputAction.CallbackContext context);
    }
}

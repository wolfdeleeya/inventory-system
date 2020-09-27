// GENERATED AUTOMATICALLY FROM 'Assets/Controls/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b057c2bc-093b-4a87-8daa-c15e4b84c08b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ea833201-54d2-4eda-816e-7937905efbb0"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""b0f928cc-2d2c-4aca-99d2-669b878ef2da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""4eac678d-560e-4b40-b805-18f920f86598"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Equip"",
                    ""type"": ""Button"",
                    ""id"": ""8e30923b-d094-44d6-ba9a-91699f6bc3d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attributes"",
                    ""type"": ""Button"",
                    ""id"": ""dcb6ee6c-d2d5-4bd7-a2ba-7f35870a1519"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""357742ba-d0f7-449f-b7bf-8a66fb259e47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Spawn"",
                    ""type"": ""Button"",
                    ""id"": ""7df30d6b-f152-4c2a-95f9-d18ef742e867"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""View"",
                    ""type"": ""Button"",
                    ""id"": ""ea7d8dee-01e1-4f5f-bbfd-a00a9c393489"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pickup"",
                    ""type"": ""Button"",
                    ""id"": ""c3ee8968-d368-43ce-a0a3-af3c55df9fca"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Arrows"",
                    ""id"": ""e7e0f65b-6220-4cf3-b038-9539ea632f43"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ec72abfc-b75f-48e1-8577-d6c2eb6a3db5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3d816475-1faa-40a1-a32e-bc6e1141a5a4"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03285dd9-21ad-4d92-a322-1fc32cbe3803"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c737a09f-12b6-4b4a-b5ac-5feecc34ebef"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""52cb8453-bc8a-4bd0-b845-9591957b509d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""22991fb2-cbcc-41cc-96be-2ab871edf9e0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e80a538a-b6c8-428a-b340-50be0b869b09"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""322d4669-a092-4a9a-b98d-93efbc7ab81a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7f6ad848-74db-4f07-beb4-47fd759ba6b7"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""b82fb6c4-468f-4c78-acec-6bf86fe25b03"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e414ac9c-d6a7-47e1-b53f-96b81f42e49c"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""941dad79-6159-42f8-93a4-85470f1f7bf7"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Equip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c6f3840-5b70-48d9-8d94-ed1315a7e763"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attributes"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""02b01322-c1e3-4121-a9fc-871b27e74912"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc758c77-d52d-4198-899e-cec7bfe16146"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Spawn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f504189-5e14-459b-99bc-a87cd22423e0"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""View"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd042457-a0fb-42ae-aec7-71eb91c71e63"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pickup"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Click = m_Gameplay.FindAction("Click", throwIfNotFound: true);
        m_Gameplay_Inventory = m_Gameplay.FindAction("Inventory", throwIfNotFound: true);
        m_Gameplay_Equip = m_Gameplay.FindAction("Equip", throwIfNotFound: true);
        m_Gameplay_Attributes = m_Gameplay.FindAction("Attributes", throwIfNotFound: true);
        m_Gameplay_Drop = m_Gameplay.FindAction("Drop", throwIfNotFound: true);
        m_Gameplay_Spawn = m_Gameplay.FindAction("Spawn", throwIfNotFound: true);
        m_Gameplay_View = m_Gameplay.FindAction("View", throwIfNotFound: true);
        m_Gameplay_Pickup = m_Gameplay.FindAction("Pickup", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Click;
    private readonly InputAction m_Gameplay_Inventory;
    private readonly InputAction m_Gameplay_Equip;
    private readonly InputAction m_Gameplay_Attributes;
    private readonly InputAction m_Gameplay_Drop;
    private readonly InputAction m_Gameplay_Spawn;
    private readonly InputAction m_Gameplay_View;
    private readonly InputAction m_Gameplay_Pickup;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Click => m_Wrapper.m_Gameplay_Click;
        public InputAction @Inventory => m_Wrapper.m_Gameplay_Inventory;
        public InputAction @Equip => m_Wrapper.m_Gameplay_Equip;
        public InputAction @Attributes => m_Wrapper.m_Gameplay_Attributes;
        public InputAction @Drop => m_Wrapper.m_Gameplay_Drop;
        public InputAction @Spawn => m_Wrapper.m_Gameplay_Spawn;
        public InputAction @View => m_Wrapper.m_Gameplay_View;
        public InputAction @Pickup => m_Wrapper.m_Gameplay_Pickup;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Click.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Inventory.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInventory;
                @Equip.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquip;
                @Equip.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquip;
                @Equip.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEquip;
                @Attributes.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttributes;
                @Attributes.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttributes;
                @Attributes.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnAttributes;
                @Drop.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDrop;
                @Spawn.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawn;
                @Spawn.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawn;
                @Spawn.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawn;
                @View.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @View.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnView;
                @Pickup.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickup;
                @Pickup.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickup;
                @Pickup.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickup;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Equip.started += instance.OnEquip;
                @Equip.performed += instance.OnEquip;
                @Equip.canceled += instance.OnEquip;
                @Attributes.started += instance.OnAttributes;
                @Attributes.performed += instance.OnAttributes;
                @Attributes.canceled += instance.OnAttributes;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Spawn.started += instance.OnSpawn;
                @Spawn.performed += instance.OnSpawn;
                @Spawn.canceled += instance.OnSpawn;
                @View.started += instance.OnView;
                @View.performed += instance.OnView;
                @View.canceled += instance.OnView;
                @Pickup.started += instance.OnPickup;
                @Pickup.performed += instance.OnPickup;
                @Pickup.canceled += instance.OnPickup;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnEquip(InputAction.CallbackContext context);
        void OnAttributes(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnSpawn(InputAction.CallbackContext context);
        void OnView(InputAction.CallbackContext context);
        void OnPickup(InputAction.CallbackContext context);
    }
}

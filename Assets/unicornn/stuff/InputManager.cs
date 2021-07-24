// GENERATED AUTOMATICALLY FROM 'Assets/unicornn/InputManager.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputManager : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputManager()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputManager"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bc66c226-26a8-4c11-a597-fecbf0d921a1"",
            ""actions"": [
                {
                    ""name"": ""Move_Down"",
                    ""type"": ""Button"",
                    ""id"": ""c481ff6f-48a1-47ae-b955-d2443b82be49"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Up"",
                    ""type"": ""Button"",
                    ""id"": ""81a41968-96dd-4485-95cf-72efb526afac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Left"",
                    ""type"": ""Button"",
                    ""id"": ""7c64e202-d51c-4f4a-8e3a-566aa108670f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move_Right"",
                    ""type"": ""Button"",
                    ""id"": ""f386bf66-8927-4690-9242-1ba36193ccef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2afbb51d-6c49-4e1d-b8bf-604edc1ddeed"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move_Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84a3c56c-1e95-41fb-b48c-468645913b7c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move_Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d19c6227-b0d9-495b-9eed-b0360f676eeb"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f9b590e-62b4-429f-a66d-ef1854f7063b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move_Down = m_Player.FindAction("Move_Down", throwIfNotFound: true);
        m_Player_Move_Up = m_Player.FindAction("Move_Up", throwIfNotFound: true);
        m_Player_Move_Left = m_Player.FindAction("Move_Left", throwIfNotFound: true);
        m_Player_Move_Right = m_Player.FindAction("Move_Right", throwIfNotFound: true);
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
    private readonly InputAction m_Player_Move_Down;
    private readonly InputAction m_Player_Move_Up;
    private readonly InputAction m_Player_Move_Left;
    private readonly InputAction m_Player_Move_Right;
    public struct PlayerActions
    {
        private @InputManager m_Wrapper;
        public PlayerActions(@InputManager wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move_Down => m_Wrapper.m_Player_Move_Down;
        public InputAction @Move_Up => m_Wrapper.m_Player_Move_Up;
        public InputAction @Move_Left => m_Wrapper.m_Player_Move_Left;
        public InputAction @Move_Right => m_Wrapper.m_Player_Move_Right;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move_Down.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Down;
                @Move_Down.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Down;
                @Move_Down.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Down;
                @Move_Up.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Up;
                @Move_Up.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Up;
                @Move_Up.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Up;
                @Move_Left.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Left;
                @Move_Left.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Left;
                @Move_Left.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Left;
                @Move_Right.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Right;
                @Move_Right.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Right;
                @Move_Right.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove_Right;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move_Down.started += instance.OnMove_Down;
                @Move_Down.performed += instance.OnMove_Down;
                @Move_Down.canceled += instance.OnMove_Down;
                @Move_Up.started += instance.OnMove_Up;
                @Move_Up.performed += instance.OnMove_Up;
                @Move_Up.canceled += instance.OnMove_Up;
                @Move_Left.started += instance.OnMove_Left;
                @Move_Left.performed += instance.OnMove_Left;
                @Move_Left.canceled += instance.OnMove_Left;
                @Move_Right.started += instance.OnMove_Right;
                @Move_Right.performed += instance.OnMove_Right;
                @Move_Right.canceled += instance.OnMove_Right;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove_Down(InputAction.CallbackContext context);
        void OnMove_Up(InputAction.CallbackContext context);
        void OnMove_Left(InputAction.CallbackContext context);
        void OnMove_Right(InputAction.CallbackContext context);
    }
}

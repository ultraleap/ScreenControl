using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ultraleap.ScreenControl.Client.ScreenControlTypes;

namespace Ultraleap.ScreenControl.Client
{
    [DefaultExecutionOrder(-1)]
    public class InputActionManager : MonoBehaviour
    {
        public delegate void ClientInputActionEvent(ClientInputAction _inputData);
        public event ClientInputActionEvent TransmitInputAction;

        public static InputActionManager Instance;

        [Tooltip("These plugins modify InputActions and are performed in order.")]
        public InputActionPlugin[] plugins;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                return;
            }
            Instance = this;
        }

        public void SendInputAction(ClientInputAction _inputAction)
        {
            RunPlugins(ref _inputAction);

            if(_inputAction != null)
            {
                TransmitInputAction?.Invoke(_inputAction);
            }
        }

        void RunPlugins(ref ClientInputAction _inputAction)
        {
            // Send the input action through the plugins in order
            // if it is returned null from a plugin, return it to be ignored
            foreach(var plugin in plugins)
            {
                if (_inputAction == null)
                {
                    return;
                }

                plugin.RunPlugin(ref _inputAction);
            }
        }
    }
}
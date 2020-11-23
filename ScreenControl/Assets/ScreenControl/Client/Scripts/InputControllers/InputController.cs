﻿using UnityEngine;
using UnityEngine.EventSystems;


namespace Ultraleap.ScreenControl.Client
{
    namespace InputControllers
    {
        /// <summary>
        /// A base Input Controller to derive from. This base class handles moving the standard cursor.
        /// </summary>
        public abstract class InputController : BaseInput
        {
            int customInputActionListeners = 0;

            protected override void Start()
            {
                base.Start();
                InputActionManager.Instance.TransmitInputAction += HandleInputAction;
            }

            protected override void OnDestroy()
            {
                base.OnDestroy();

                if (InputActionManager.Instance != null)
                {
                    InputActionManager.Instance.TransmitInputAction -= HandleInputAction;
                }
            }

            protected virtual void HandleInputAction(ScreenControlTypes.ClientInputAction _inputData)
            {
                switch (_inputData.InputType)
                {
                    case ScreenControlTypes.InputType.MOVE:
                        break;
                    case ScreenControlTypes.InputType.DOWN:
                        break;
                    case ScreenControlTypes.InputType.UP:
                        break;
                    case ScreenControlTypes.InputType.CANCEL:
                        break;
                }
            }
        }
    }
}
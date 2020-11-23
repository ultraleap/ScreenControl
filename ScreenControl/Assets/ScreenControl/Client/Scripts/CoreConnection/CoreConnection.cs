using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ultraleap.ScreenControl.Client
{
    public abstract class CoreConnection
    {
        public abstract void Disconnect();

        protected void BroadcastInputAction(ScreenControlTypes.ClientInputAction _inputData)
        {
            InputActionManager.Instance.SendInputAction(_inputData);
        }
    }
}
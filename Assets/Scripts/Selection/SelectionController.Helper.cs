using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SelectionController : AbstractSingleton<SelectionController>
{
    private bool CancelCommandInstead()
    {
        CommandController commandController = CommandController.Instance;
        bool isCommanding = commandController.InUse();
        if (isCommanding)
        {
            commandController.Cancel();
            return true;
        }
        return false;
    }
}

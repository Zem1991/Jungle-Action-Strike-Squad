using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AbilityDecisionProcessor
{
    public void Process(Character character)
    {
        AbilityController abilityController = AbilityController.Instance;
        bool fromContext = abilityController.FromContext;
        bool withCurrent = abilityController.Current != null;

        AbilityInstanceContextProcessor contextProcessor = new AbilityInstanceContextProcessor();
        AbilityInstance contextAI = contextProcessor.Process(character);

        if (fromContext)
        {
            if (withCurrent) ContextWithCurrent(contextAI);
            else ContextNoCurrent(contextAI);
        }
        else
        {
            if (withCurrent) DirectWithCurrent();
            else DirectNoCurrent();
        }
    }

    private void ContextWithCurrent(AbilityInstance fromContext)
    {
        AbilityController abilityController = AbilityController.Instance;
        bool isSame = abilityController.Compare(fromContext);
        if (isSame) abilityController.Execute();
        else abilityController.Set(fromContext, true);
    }

    private void ContextNoCurrent(AbilityInstance fromContext)
    {
        AbilityController abilityController = AbilityController.Instance;
        abilityController.Set(fromContext, true);
    }

    private void DirectWithCurrent()
    {
        AbilityController abilityController = AbilityController.Instance;
        abilityController.Execute();
    }

    private void DirectNoCurrent()
    {
        //TODO??
    }
}

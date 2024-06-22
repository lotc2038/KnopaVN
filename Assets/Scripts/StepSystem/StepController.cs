using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public List<IStep> steps = new List<IStep>();
    public int currentStepIndex = 0;

    public void AddStep(IStep step)
    {
        steps.Add(step);
    }

    public void ExecuteNextStep()
    {
        if (currentStepIndex < steps.Count)
        {
            steps[currentStepIndex].Execute();
            currentStepIndex++;
        }
        else
        {
            Debug.Log("No steps left");

        }
    }
}


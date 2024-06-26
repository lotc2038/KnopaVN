using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{
    public List<Step> steps = new List<Step>();
    public int currentStepIndex = 0;

    public void AddStep(Step step)
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


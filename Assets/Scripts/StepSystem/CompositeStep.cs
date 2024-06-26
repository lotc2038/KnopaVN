using System.Collections.Generic;

public class CompositeStep : Step
{
    private List<Step> steps;

    public CompositeStep(List<Step> steps)
    {
        this.steps = steps;
    }

    public override void Execute()
    {
        foreach (var step in steps)
        {
            step.Execute();
        }
    }
}

using System.Collections.Generic;

public class CompositeStep : IStep
{
    private List<IStep> steps;

    public CompositeStep(List<IStep> steps)
    {
        this.steps = steps;
    }

    public void Execute()
    {
        foreach (var step in steps)
        {
            step.Execute();
        }
    }
}

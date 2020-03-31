using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasks
{
    public virtual bool run() { return false; }
}

public class selector : tasks
{
    List<tasks> children;
    tasks currentTask;
    int currentTaskIndex = 0;

    public selector(List<tasks> taskList)
    {
        children = taskList;
    }

    public override bool run()
    {
        foreach (tasks i in children)
        {
            if (i.run())
            {
                return true;
            }
        }
        return false;
    }
}

public class sequence : tasks
{
    List<tasks> children;
    tasks currentTask;
    int currentTaskIndex = 0;

    public sequence(List<tasks> taskList)
    {
        children = taskList;
    }

    public override bool run()
    {
        foreach (tasks i in children)
        {
            if (!i.run())
            {
                return false;
            }
        }
        return true;
    }
}

public class OpenDoor : tasks
{

    public override bool run()
    {
        Debug.Log("The door is now open!");
        return true;
    }
}

public class BargeDoor : tasks
{
    public override bool run()
    {
        Debug.Log("You hit the shoulder on the door.");
        return true;
    }
}



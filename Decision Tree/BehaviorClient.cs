using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorClient : MonoBehaviour
{
    bool executingBehavior = false;
    tasks myCurrentTask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!executingBehavior)
            {
                myCurrentTask = getCurrentTask();
                executingBehavior = true;
                myCurrentTask.run();
            }
        }
    }

    public tasks getCurrentTask()
    {
        List<tasks> taskList = new List<tasks>();

        tasks openDoor = new OpenDoor();
        tasks bargeIn = new BargeDoor();

        taskList.Add(openDoor);
        taskList.Add(bargeIn);

        sequence bargeClosedDoor = new sequence(taskList);

        return bargeClosedDoor;
    }
}



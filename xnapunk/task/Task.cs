using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace xnapunk.task
{
    //A Task (function) to be called after a certain amount of time
    public class Task
    {

        //This delegate specifys the type of function that will be called at the end of the task
        public delegate void TaskFn(ref object state);
        //The callback
        public TaskFn fn;
        //How long before the task runs
        private int delay;
        //This stores data passed to a TaskFn
        public object state;
        //Internal timer to compare to delay
        protected int count;
        //Is it running? (Pausable with this variable)
        public bool running = true;

        public Task(TaskFn fn, int delay, object state)
        {
            this.fn = fn;
            this.delay = delay;
            this.state = state;
        }

        //This is called each frame, similar to update on Entities
        virtual public void tick()
        {
            //Don't increase time if running
            if (!running) return;
            count++;
            //It's time to run!
            if (count > delay) finish();
        }

        //Delete this Task
        public void die()
        {
            running = false;
            XP.World.Tasks.Remove(this);
        }

        //Call this to end
        virtual protected void finish()
        {
            //Call the function with parameter of the state
            fn(ref state);
            //Delete
            die();
        }

    }
}
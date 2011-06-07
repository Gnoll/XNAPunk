using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace xnapunk.task
{
    class RepeatingTask : Task
    {

        //If not -1, run for this length
        private int lifetime = -1;
        //How many times did we run
        private int life = 0;

        public RepeatingTask(TaskFn fn, int delay, int lifetime, object state) : base(fn, delay, state) { this.lifetime = lifetime; }

        override public void tick()
        {
            //Perform regular Task...
            base.tick();
            life++;
            //Die if we ran for too long
            if (lifetime != -1 && life > lifetime) die();
        }

        override protected void finish()
        {
            fn(ref state);
            //Reset the count so we run again
            count = 0;
        }

    }
}

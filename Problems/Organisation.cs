using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Problems
{
    class Manager
    {
        Project XProject { get; set; }
        public Manager()
        {
            XProject = new Project(this);
        }
     
       public int Salary { get; set; }

        //Aggregation
        List<Worker> Workers = new List<Worker>();
        public void Login(SwipeCard card)
        {
            card.Swipe(this);
        }     

        public void IsManagerGood(bool good)
        {
            if(good)
            {
                XProject.IsSuccess = true;
            }
            else
            {
                XProject.IsSuccess = false;
            }
        }


    }

    class SwipeCard
    {
        public void Swipe(Manager managerObj)
        {
            //Swipes the manager
        }
    }

    class Worker
    {

    }

    class Project
    {
        public bool IsSuccess { get; set; } = false;

        public Manager manager { get; set; }

        public Project(Manager oManager)
        {
            if(IsSuccess)
            {
                manager = oManager;
                if(IsSuccess)
                {
                    manager.Salary++;
                }
                else
                {
                    manager.Salary--;
                }
            }
        }
    }
}

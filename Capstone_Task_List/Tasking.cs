using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone_Task_List
{
    class Tasking
    {
        #region fields
        private string _name;
        private string _description;
        private DateTime _duedate;
        private bool _completed;
        #endregion

        #region Properties

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
        #endregion
        #region Constructors

        public Tasking()
        {

        }

        public Tasking(string name, string description, DateTime duedate, bool completed)
        {
            _name = name;
            _description = description;
            _duedate = duedate;
            _completed = completed;
        }
        #endregion

        #region Methods
        public void Complete()
        {
            Completed = true;
        }
        public void PrintTasks() 
        {
            if (Completed == false)
            {
                Console.WriteLine($"{Name} has to {Description}, which is due on {DueDate}, and has not been completed.");
            }
            else
            {
                Console.WriteLine($"{Name} has to {Description}, which was due on {DueDate}, and is marked complete."); 
            }

        }
        #endregion

    }
}

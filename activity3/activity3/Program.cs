using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace activity3
{
    public class WorkItem
    {
        public static int currentID;
        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }
        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default description";
            jobLength = new TimeSpan();

        }
        public WorkItem(string title,string desc,TimeSpan jobLen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = jobLen;
        }
        static WorkItem ()
        {
            currentID = 0;
        }
        protected int GetNextID()
        {
            return ++currentID;
        }
        public void Update(string title,TimeSpan jobLen)
        {
            this.Title= title;  
            this.jobLength= jobLen;
        }
        public override string ToString()
        {
            return string.Format("{0} - {1}", this.ID, this.Title);
        }
    }
    public class ChangeRequest : WorkItem
    {
        protected int orignalItemId { get; set; }
        public ChangeRequest() { }
        public ChangeRequest(string title, string desc, TimeSpan joblen, int orignalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;

        }
        public ChangeRequest(int orignalItemID)
        {
            this.orignalItemId= orignalItemID;

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            WorkItem workItem = new WorkItem("Fix bugs","fix all bugs in my code branch",new TimeSpan(3,4,0,0));
            ChangeRequest change= new ChangeRequest("change base class design", "add members to the class",new TimeSpan(4,0,0),1);
            Console.WriteLine(workItem.ToString());
            change.Update("change the design of the base class ", new TimeSpan(4, 0, 0));
            Console.WriteLine(change.ToString());
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}

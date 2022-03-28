using System.Collections;
using System.Collections.ObjectModel;

namespace Task_1
{
    interface IConsultant
    {
        public void Save(Consultant client, object clients, int index);
    }
    interface IManager
    {
        public void Save(Manager client, object clients, int index);
        public void Add(Manager client, object clients);
    }

  
}
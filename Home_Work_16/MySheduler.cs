using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork;

public partial class Program
{
    public class MySheduler : TaskScheduler
    {
        private readonly LinkedList<Task> _listTasks = new LinkedList<Task>();


        protected override IEnumerable<Task>? GetScheduledTasks()
        {
            return _listTasks;
        }

        protected override void QueueTask(Task task)
        {
            Thread.Sleep(rnd.Next(300, 3000));
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Задача #{task.Id} поставлена в очередь на выполенение");
            Console.ResetColor();

            _listTasks.AddLast(task);
            ThreadPool.QueueUserWorkItem(ExecuteTasks, null);

        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Попытка выполнить задачу #{task.Id} синхронно..");
            Console.ResetColor();

            lock (_listTasks)
            {
                _listTasks.Remove(task);
            }

            return base.TryExecuteTask(task);
        }

        protected override bool TryDequeue(Task task)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Попытка удалить задачу {task.Id} из очереди..!");
            Console.ResetColor();

            bool result = false;

            lock (_listTasks)
            {
                result = _listTasks.Remove(task);
            }

            if (result == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Задача {task.Id} была удалена из очереди на выполнение..");
                Console.ResetColor();
            }

            return result;
        }

        private void ExecuteTasks(object _)
        {
            while (true)
            {
                Task task = null;

                lock (_listTasks)
                {
                    if (_listTasks.Count == 0)
                    {
                        break;
                    }

                    task = _listTasks.First.Value;
                    _listTasks.RemoveFirst();
                }

                if (task == null)
                {
                    break;
                }

                base.TryExecuteTask(task);
            }
        }

    }
}
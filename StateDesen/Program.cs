using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDesen // bir nesnenin yada durumun herneyse durumunu öğrenmek için kullanılır, play, pause music calar gibi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Context context= new Context();
            ModifiedState modified = new ModifiedState();
            modified.doAction(context);
            DeletedState deleted = new DeletedState();
            deleted.doAction(context);

            Console.WriteLine(context.GetState());

            Console.ReadLine();


        }
    }

    interface IState
    {
        void doAction(Context context);
    }
    class ModifiedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State: Modified");
            context.SetState(this);
        }
    }

    class DeletedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State: Deleted");
            context.SetState(this);

        }
    }

    class AddedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State: Added");
            context.SetState(this);
        }
    }

    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}

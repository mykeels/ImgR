using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ImgR
{
    internal class Promise<T>
    {
        public Promise<T>.State state { get; set; }
        public Thread current { get; set; }
        private Action<T> success { get; set; }
        private List<Action<T>> then = new List<Action<T>>();
        private Action done { get; set; }
        private Action<Exception> error { get; set; }
        private Func<T> work { get; set; }
        private int timeout { get; set; }

        public Promise(Func<T> func)
        {
            this.state = State.Pending;
            this.work = func;
            this.Execute();
        }

        public static Promise<T> Create(Func<T> func)
        {
            return new Promise<T>(func);
        }

        private void Execute()
        {
            current = new Thread(() =>
            {
                innerExecute();
            });
            current.SetApartmentState(ApartmentState.STA);
            current.Start();
        }

        private void innerExecute()
        {
            try
            {
                dynamic result = work();
                if (success != null)
                {
                    success(result);
                }
                if (then.Count > 0)
                {
                    then.ForEach((action) =>
                    {
                        action(result);
                    });
                }
                if (state.Equals(State.Pending)) state = State.Fulfilled;
            }
            catch (Exception ex)
            {
                if (state.Equals(State.Pending)) state = State.Rejected;
                if (error != null) error(ex);
                else
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
            }
            try
            {
                if (done != null) done();
            }
            catch (Exception ex)
            {
                if (state.Equals(State.Pending)) state = State.Rejected;
                if (error != null) error(ex);
                else
                {
                    Console.WriteLine(ex);
                    throw ex;
                }
            }
        }

        public Promise<T> Wait()
        {
            this.current.Join();
            return this;
        }

        public Promise<T> Success(Action<T> act)
        {
            this.success = act;
            return this;
        }

        public Promise<T> Then(Action<T> act)
        {
            this.then.Add(act);
            return this;
        }

        public Promise<T> Done(Action act)
        {
            this.done = act;
            return this;
        }

        public Promise<T> Error(Action<Exception> act)
        {
            this.error = act;
            return this;
        }

        public Promise<T> SetTimeOut(int t)
        {
            this.timeout = t;
            if (timeout > 0) this.ExecuteTimeOut();
            return this;
        }

        private void ExecuteTimeOut()
        {
            Thread th = new Thread(() =>
            {
                Thread.Sleep(timeout);
                if (state == State.Pending)
                {
                    current.Abort();
                    if (state.Equals(State.Pending)) state = State.Rejected;
                    if (error != null) error(new Exception("Process time out"));
                }
            });
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public enum State
        {
            Pending,
            Fulfilled,
            Rejected
        }
    }
}

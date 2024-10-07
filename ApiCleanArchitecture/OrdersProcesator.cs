namespace ApiCleanArchitecture
{
    public abstract class OrdersProcesator
    {
        protected OrdersProcesator  _next;

        public void AddNext(OrdersProcesator ToNext) 
        { 
            _next = ToNext;
        }
        public abstract void Processing(Order ToSend);
    }
}

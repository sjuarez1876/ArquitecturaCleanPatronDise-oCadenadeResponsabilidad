namespace ApiCleanArchitecture
{
    public class OrderProccesingQuantityProducts : OrdersProcesator
    {
        public override void Processing(Order ToSend)
        {
            if (ToSend != null && ToSend.Quantity > 2)
            {
                base._next.Processing(ToSend);
            }
            else
            {
                throw new Exception("No se pueden procesar pedidos pequeños");
            }
        }
    }
}

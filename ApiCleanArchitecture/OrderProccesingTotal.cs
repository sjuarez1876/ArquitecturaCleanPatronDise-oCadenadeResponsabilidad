namespace ApiCleanArchitecture
{
    public class OrderProccesingTotal : OrdersProcesator
    {
        public override void Processing(Order ToSend)
        {
            if (ToSend != null && ToSend.Total > 20)
            {
                base._next.Processing(ToSend);
            }
            else 
            { 
                throw new Exception("Error no se pueden procesar pedidos menores a 20 pesos");
            }
            
        }

    }
}

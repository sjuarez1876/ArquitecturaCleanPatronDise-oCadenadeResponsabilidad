namespace ApiCleanArchitecture
{
    public class OrderProccesingAvailableProduct : OrdersProcesator
    {
        public override void Processing(Order ToSend) 
        {
            if (ToSend != null && ToSend.Product == "galletas")
            {
                base._next.Processing(ToSend);

            }
            else 
            { 
                throw new Exception("Error, no se pueden procesar productos diferentes a galletas");
            
            }
        
        }
    }
}

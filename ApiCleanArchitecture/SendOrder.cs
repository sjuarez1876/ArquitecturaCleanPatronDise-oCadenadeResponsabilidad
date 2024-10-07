namespace ApiCleanArchitecture
{
    public class SendOrder : OrdersProcesator
    {
        public override void Processing(Order ToSend) 
        {
            Console.WriteLine($"pedido { ToSend.Id } procesado ");
        }
    }
}

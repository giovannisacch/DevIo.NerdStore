namespace DevIo.NerdStore.Core.Messages
{
    public class CommandHandler
    {
        protected virtual bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                //Lançar evento de erro
            }

            return false;
        }
    }
}
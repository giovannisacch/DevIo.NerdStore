using System;
using MediatR;

namespace DevIo.NerdStore.Core.Messages
{
    public abstract class Event : Message, INotification
    {
        //Inotificaiton e uma interface de marcacao
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
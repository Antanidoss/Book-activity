﻿using NetDevPack.Messaging;
using System;

namespace BookActivity.Domain.Events.ActiveBookEvent
{
    public sealed class RemoveActiveBookEvent : Event
    {
        public RemoveActiveBookEvent(Guid activeBookId)
        {
            ActiveBookId = activeBookId;
        }

        public Guid ActiveBookId { get; private set; }
    }
}
﻿using System;

namespace SettlersOfCatan.Domain
{
    public class IdentifiableBase
    {
        private protected Guid _id = Guid.NewGuid();
        public Guid Id { get { return _id; } }
    }
}

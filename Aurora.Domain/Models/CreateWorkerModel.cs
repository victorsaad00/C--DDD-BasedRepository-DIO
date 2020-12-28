﻿using System;

namespace Aurora.Domain.Models
{
    public class CreateWorkerModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Cpf { get; set; }

        public string Password { get; set; }
    }
}

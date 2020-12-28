using Aurora.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aurora.Domain.Entities {
    public class Manager : BaseEntity<int> {
        public Manager(Name name, Cpf cpf, Password password) {
            AddNotifications(
                name.contract,
                cpf.contract,
                password.contract);

            if (Valid) {
                Name = name;
                Cpf = cpf;
                Password = password;
            }
        }

        protected Manager() { }

        public Name Name { get; }

        public Cpf Cpf { get; }

        public Password Password { get; }
    }
}

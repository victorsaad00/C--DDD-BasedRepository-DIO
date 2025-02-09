﻿using Flunt.Validations;
using System;
using System.Collections.Generic;

namespace Aurora.Domain.Entities
{
    public class PersonalProtectiveEquipment : BaseEntity<int> {
        public PersonalProtectiveEquipment(string description, int quantity, string approvalCertificate, DateTime manufacturingDate, int durability) {
            AddNotifications(
                ValidateDescription(description),
                ValidateQuantity(quantity),
                ValidateApprovalCertificate(approvalCertificate),
                ValidateManufacturingDate(manufacturingDate),
                ValidateDurability(durability));

            if (Valid) {
                Description = description;
                Quantity = quantity;
                ApprovalCertificate = approvalCertificate;
                ManufacturingDate = manufacturingDate;
                Durability = durability;
            }
        }

        protected PersonalProtectiveEquipment() { }

        public string Description { get; }

        public int Quantity { get; }

        public string ApprovalCertificate { get; }

        public DateTime ManufacturingDate { get; }

        public int Durability { get; }

        public virtual IEnumerable<PpePossession> PpePossessions { get; set; }

        public bool HasExpired() =>
            ManufacturingDate.AddDays(Durability) < DateTime.Now;

        private Contract ValidateDescription(string description) =>
            new Contract()
                .HasMinLen(description, 10, nameof(Description), "")
                .IsNotNullOrWhiteSpace(description, nameof(Description), "");

        private Contract ValidateQuantity(int quantity) =>
            new Contract()
                .IsLowerOrEqualsThan(quantity, 0, nameof(Quantity), "");

        private Contract ValidateApprovalCertificate(string approvalCertificate) =>
            new Contract()
                .IsNotNullOrWhiteSpace(approvalCertificate, nameof(ApprovalCertificate), "");

        private Contract ValidateManufacturingDate(DateTime manufacturingDate) =>
            new Contract()
                .IsGreaterThan(manufacturingDate, DateTime.Now, nameof(ManufacturingDate), "");

        private Contract ValidateDurability(int durability) =>
            new Contract()
                .IsLowerOrEqualsThan(durability, 0, nameof(Durability), "");
    }
}

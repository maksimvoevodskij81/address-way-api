﻿using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace TaskAPI.Contracts.V1.Responses
{
    public class AddressResponse
    {
        public int? Id { get; private set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
    }
}

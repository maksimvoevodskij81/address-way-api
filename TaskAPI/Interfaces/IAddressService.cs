﻿using BackendData.DomainModel;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Contracts.V1.Requests.Query;
using TaskAPI.Contracts.V1.Responses;

namespace TaskAPI.Interfaces;

public interface IAddressService
{
	Task<Address> CreateAndSaveAddress(AddressCreateRequest address);
	Task<Address> GetAddressByIdAsync(int addressId);
    Task<IReadOnlyList<Address>> RetrieveAllAddress(GetAllAddressSortFilter? sort = null, string? filter = null,
    PaginationFilter? paginationFilter = null);

    Task<bool> UpdateAddressAsync(AddressUpdateRequest address, int addressId);
    Task<bool> DeleteAddressAsync(int addressId);
}
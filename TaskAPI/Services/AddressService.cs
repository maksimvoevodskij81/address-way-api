﻿using BackendData;
using BackendData.DomainModel;
using System.Collections.Generic;
using TaskAPI.Contracts.V1.Requests;
using TaskAPI.Interfaces;

namespace TaskAPI.Services;

public class AddressService : IAddressService
{
	private readonly IAsyncRepository<Address> _addressRepository;

	public AddressService(IAsyncRepository<Address> addressRepository)
	{
		_addressRepository = addressRepository;
	}

	public async Task<Address> CreateAndSaveAddress(AddressCreateRequest newAddress)
	{
		var address = new Address
		{
			Country= newAddress.Country,
			City=newAddress.City,
			Street=newAddress.Street,
			HouseNumber=newAddress.HouseNumber,
			ZipCode = newAddress.ZipCode
		};

		 await _addressRepository.AddAsync(address);
		return address;
	}

	public async Task<IReadOnlyList<Address>> RetrieveAllAddress(GetAllSortFilter? sort = null, 
		GetAllSearchFilter? filter = null,PaginationFilter? paginationFilter = null)
	{
        return await _addressRepository.ListAllAsync(sort!, filter!, paginationFilter!);
    }

	public async Task<Address> GetAddressByIdAsync(int id) 
	{
	    return await _addressRepository.GetByIdAsync(id);
    }

	public async Task<bool> UpdateAddressAsync(AddressUpdateRequest addressRequest, int addressRequstId )
	{
		var addressForUpdate = await GetAddressByIdAsync(addressRequstId);
		if(addressForUpdate is null) 
			return false;
		addressForUpdate.Country = addressRequest.Country;
		addressForUpdate.City = addressRequest.City;
		addressForUpdate.Street = addressRequest.Street;
		addressForUpdate.HouseNumber = addressRequest.HouseNumber;
		addressForUpdate.ZipCode = addressRequest.ZipCode;
		await _addressRepository.UpdateAsync(addressForUpdate);
		return true;
	}

    public async Task<bool> DeleteAddressAsync(int addressRequstId)
    {
        var addressForUpdate = await GetAddressByIdAsync(addressRequstId);
        if (addressForUpdate is null)
            return false;
        await _addressRepository.DeleteAsync(addressForUpdate);
        return true;
    }
}

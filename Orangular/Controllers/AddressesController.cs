﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orangular.DTO.Addresses.Requests;
using Orangular.DTO.Addresses.Responses;
using Orangular.Services.addresses;



namespace Orangular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressesService _addressService;

        public AddressesController(IAddressesService addressService)
        {
            // _authorService far værdien authoerService
            _addressService = addressService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<AddressesResponse> Addresses = await _addressService.getAll();

                if (Addresses == null)
                {
                    string problem = "Got no data, not even an empty list, this is unexpected";
                    return Problem(problem);
                }

                if (Addresses.Count == 0) return NoContent();

                return Ok(Addresses);

            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // GetById
        [HttpGet("{addresses_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById([FromRoute] int addresses_id)
        {
            try
            {
                AddressesResponse address = await _addressService.getById(addresses_id);

                if (address == null)
                {
                    return NotFound();
                }

                return Ok(address);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Create
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] NewAddresses newAddress)
        {
            try
            {
                AddressesResponse address = await _addressService.create(newAddress);

                if (address == null)
                {
                    return Problem("Address was not created, something went wrong");
                }

                return Ok(address);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Update
        [HttpPut("{addresses_id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromRoute] int addresses_id, [FromBody] UpdateAddresses updateAddress)
        {
            try
            {
                AddressesResponse address_response = await _addressService.update(addresses_id, updateAddress);

                if (address_response == null)
                {
                    return Problem("Address was not updated, something went wrong");
                }

                return Ok(address_response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // Delete
        [HttpDelete("{address_id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] int address_id)
        {
            try
            {
                bool result = await _addressService.delete(address_id);

                if (!result)
                {
                    return Problem("Author was not deleted, something went wrong");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
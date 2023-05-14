﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticalAPI.Database_Models;
using PracticalAPI.Interfaces;

namespace PracticalAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IAll<Employee> _all;

        public EmployeeController(IAll<Employee> all)
        {
            this._all = all;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _all.GetAll();
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            try
            {
                var result = _all.Insert(employee);
                if (result != null)
                {
                    await _all.Complete();
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPut("Update")]
        public async Task<IActionResult> Update(Employee employee)
        {
            var existsData = await _all.GetById(employee.Id);
            if (existsData != null)
            {
                await _all.Update(employee);      
                await _all.Complete();
                return Ok(employee);
            }
            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _all.GetById(id);
            if (data != null)
            {
                await _all.Delete(id);
                await _all.Complete();

                return Ok();
            }

            return BadRequest();


        }

    }
}

﻿/*======================================================================
| OrderServices class
|
| Name: OrderServices.cs
|
| Written by: Chigozie Muonagolu - January 2023
|
| Purpose: Contains services available for a Order object.
|
| usage: Used in controllers and other classes that may depend on it.
|
| Description of properties: None
|
|------------------------------------------------------------------
*/
using System;
using MongoDB.Bson;
using Restaurant_Api.Services;
using Restaurant_Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        public AdminController()
        {

        }

        //Endpoint to fetch all accounts from the database
        [HttpGet]
        [Route("GetAllAdmin/{AdminId}")]
        public ActionResult<List<Admin>> GetAllAccount(string AdminId) => AdminServices.GetAll(AdminId);

        //Endpoint to login in an account
        [HttpPost]
        [Route("LoginAdmin")]
        public ActionResult<Admin> LoginAccount(Login_Credential account) => AdminServices.Login(account);

        //Endpoint to get a particular account details
        [HttpGet]
        [Route("GetAdmin/{id}")]
        public ActionResult<Admin> Get(string id) => AdminServices.Get(id);

        //Endpoint to delete any account from the database
        [HttpDelete]
        [Route("DeleteAdmin/")]
        public void DeleteAccount(string id) => AdminServices.Remove(id);

        //Endpoint to update a particular admin account
        [HttpPut]
        [Route("UpdateAdmin/")]
        public ActionResult<Admin> UpdateAccount(Admin account, string AccountoUpdate_ID)
        {
            Admin updated = AdminServices.Update(account, AccountoUpdate_ID);
            if(updated == null)
            {
                return StatusCode(400);
            }
            else
            {
                return updated;
            }

        }

        //Endpoint to add a new Admin
        [HttpPost]
        [Route("CreateAdmin/")]
        public ActionResult<Admin> CreateAccount(Admin account) => AdminServices.Add(account);
    }

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {

        }

        //Endpoint to fetch all accounts from the database
        [HttpGet]
        [Route("GetAllCustomer/{AdminId}")]
        public ActionResult<List<Customer>> GetAllAccount(string AdminId) => CustomerServices.GetAll(AdminId);

        //Endpoint to login in an account
        [HttpPost]
        [Route("LoginCustomer/")]
        public ActionResult<Customer> LoginAccount(Login_Credential account) => CustomerServices.Login(account);

        //Endpoint to get a particular account details
        [HttpGet]
        [Route("GetCustomer/{id}")]
        public ActionResult<iAccount> Get(string id) => CustomerServices.Get(id);

        //Endpoint to delete any account from the database
        [HttpDelete]
        [Route("DeleteCustomer/")]
        public void DeleteAccount(string id) => CustomerServices.Remove(id);

        //Endpoint to update a particular admin account
        [HttpPut]
        [Route("UpdateCustomer/")]
        public ActionResult<Customer> UpdateAccount(Customer account, string AccountoUpdate_ID)
        {
            Customer updated = CustomerServices.Update(account, AccountoUpdate_ID);
            if (updated == null)
            {
                return StatusCode(400);
            }
            else
            {
                return updated;
            }

        }
        //Endpoint to add a new Admin
        [HttpPost]
        [Route("CreateCustomer/")]
        public ActionResult<Customer> CreateAccount(Customer account) => CustomerServices.Add(account);
        //Endpoint to add a new Admin
        [HttpPut]
        [Route("UpdatePoint/")]
        public ActionResult<Customer> UpdatePoints(string id) => CustomerServices.UpdatePoint(id);
        //Endpoint to add a new Admin
        [HttpPut]
        [Route("ConsumePoint/")]
        public ActionResult<Customer> ConsumePoints(string id) => CustomerServices.UsePoints(id);
    }

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        public EmployeeController()
        {

        }

        //Endpoint to fetch all accounts from the database
        [HttpGet]
        [Route("GetAllEmployee/{AdminId}")]
        public ActionResult<List<Employee>> GetAllAccount(string AdminId) => EmployeeServices.GetAll(AdminId);

        //Endpoint to login in an account
        [HttpPost]
        [Route("LoginEmployee/")]
        public ActionResult<Employee> LoginAccount(Login_Credential account) => EmployeeServices.Login(account);

        //Endpoint to get a particular account details
        [HttpGet]
        [Route("GetEmployee/{id}")]
        public ActionResult<iAccount> Get(string id) => EmployeeServices.Get(id);

        //Endpoint to delete any account from the database
        [HttpDelete]
        [Route("DeleteEmployee/")]
        public void DeleteAccount(string id) => EmployeeServices.Remove(id);

        //Endpoint to update a particular Employee account
        [HttpPut]
        [Route("UpdateEmployee/")]
        public ActionResult<Employee> UpdateAccount(Employee account, string AccountoUpdate_ID)
        {
            Employee updated = EmployeeServices.Update(account, AccountoUpdate_ID);
            if (updated == null)
            {
                return StatusCode(400);
            }
            else
            {
                return updated;
            }

        }
        //Endpoint to add a Employee Admin
        [HttpPost]
        [Route("CreateEmployee/")]
        public ActionResult<Employee> CreateAccount(Employee account) => EmployeeServices.Add(account);
    }
}


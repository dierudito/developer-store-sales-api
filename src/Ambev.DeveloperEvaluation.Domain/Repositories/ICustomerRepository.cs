﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories.Base;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Defines the contract for the Customer repository.
/// </summary>
public interface ICustomerRepository : IBaseRepository<Customer>
{
}